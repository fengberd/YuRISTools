<?php
function curl_get($url, $data = null, $headers = array(), $extras = null)
{
    $headers[] = 'User-Agent: MoeBerd';
    $options = array(
        CURLOPT_URL => $url . ($data === null ? '' : '?' . (is_array($data) ? http_build_query($data) : $data)),
        CURLOPT_POST => false,
        CURLOPT_HEADER => false,
        CURLOPT_TIMEOUT => 10,
        CURLOPT_HTTPHEADER => $headers,
        CURLOPT_AUTOREFERER => true,
        CURLOPT_FOLLOWLOCATION => true,
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_SSL_VERIFYPEER => false
    );
    if ($extras != null) {
        $options += $extras;
    }
    return curl_exec_array($options);
}

$ch = curl_init();
function curl_exec_array(array $options)
{
    global $ch;
    curl_setopt_array($ch, $options);
    $data = curl_exec($ch);
    unset($options);
    return $data;
}

function loadJSON($name)
{
    return json_decode(file_get_contents($name), true);;
}

chdir('local');

$secret = loadJSON('secret.json');
function translate($text, $from = "jp", $to = "zh")
{
    global $secret;
    $cache = 'cache/baidu_' . md5($text) . '.json';
    if (file_exists($cache)) {
        $result = loadJSON($cache);
    } else {
        static $time = 0;
        if (microtime(true) - $time < 2) {
            sleep(1);
        }
        $time = microtime(true);
        $salt = mt_rand(1000000000, 9999999999);
        $result = json_decode(curl_get('https://fanyi-api.baidu.com/api/trans/vip/translate', array(
            'q' => $text,
            'from' => $from,
            'to' => $to,
            'appid' =>  $secret['appid'],
            'salt' => $salt,
            'sign' => md5($secret['appid'] . $text . $salt .  $secret['key'])
        )), true);
        if (!is_array($result) || !isset($result['trans_result'])) {
            logOut(var_export($result, true));
            return false;
        }
        file_put_contents($cache, json_encode($result, JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE));
    }
    return implode('', array_map(function ($v) {
        return $v['dst'];
    }, $result['trans_result']));
}

$data = loadJSON('all.json');
$names = loadJSON('names.json');

function logOut($data)
{
    echo ($data .= "\n");
    file_put_contents('translate.log', $data, FILE_APPEND);
}

$result = array();
foreach ($data as $key => $val) {
    logOut('---- Enter ' . $key . ' ----');
    $result[$key] = array();
    foreach ($val as $str) {
        logOut(mb_strlen($str) > 36 ? (mb_substr($str, 0, 32) . '...') : $str);
        $pos = mb_strpos($str, '「');
        if ($pos !== false && mb_substr($str, -1) == '」') {
            $name = mb_substr($str, 0, $pos);
            $name = $names[$name] ?? $name;
            $str = mb_substr($str, $pos + 1);
            if (!($str =  translate(mb_substr($str, 0, mb_strlen($str) - 1)))) {
                logOut(' -> (Failed)');
                $result[$key][]  = null;
                continue;
            }
            $str =  $result[$key][] = $name .  '「' . $str . '」';
        } else {
            if (!($str =  translate($str))) {
                logOut(' -> (Failed)');
                $result[$key][]  = null;
                continue;
            }
            $result[$key][] = $str;
        }
        logOut(' -> ' . (mb_strlen($str) > 36 ? (mb_substr($str, 0, 32) . '...') : $str));
    }
    logOut('---- END OF ' . $key . ' ----');
    file_put_contents('translate.json', json_encode($result, JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE));
}
