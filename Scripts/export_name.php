<?php
chdir('local');

$data = json_decode(file_get_contents('all.json'), true);
$names = array();
foreach ($data as $val) {
    foreach ($val as $str) {
        $pos = mb_strpos($str, '「');
        if ($pos !== false && mb_substr($str, -1) == '」') {
            $names[$str = mb_substr($str, 0, $pos)] = $str;
        }
    }
}
file_put_contents('names.json', json_encode($names, JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE));
