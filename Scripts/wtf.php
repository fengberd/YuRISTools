<?php
$data = '////////////7MU2Et9HuKf
Pz4ifIT3CBSkeqxLsEnFVVj
26u7NieXQOcBzOxXl3bMbHH
TzDSKhRtyJM8CXAqqwYJpsC
AOBiWdcxZfQ9HKmHfREsSip
KPwSdmUNHmtKGcFiudktOiO
Y5KCFn9CORVY8sFcMF3RISl
hoNvfrmjVgH41WhJDVOWuzv
VdwlzOJjvLUI9vOqTzZIyd9
b1iDi3niJHDMnxMxLeLoW5F
aWPgXjl2MS1vvoRpC54NE4F
r7tmsgcZdAIq3KOXJsACNXn
rUVGTWxfQZL3fp9QZm3oKyi
PNN5TeRRzoJ9DBy2Hx3vRb4
Bxi4KAoi4Qu528ySaJrEppq
8n9ITveVE7gdQkgQuyPJDId
4o7b3SaAIfpFP2PNYFGPxrQ
oULgxas7t7NKGEREXkMSCOn
cf6QXaZc6mcw4E51PaJn47P
h62pAnqB55sSXMiDXmQc4D2
BBUtJuS3h9iQbkLctfaAgh0
Yo7vSeFp3wEXA8EvDmI3tcd
psHxA4yZSzM3CCScPLwhu3d
OgHVLApyb9MIXaiI8FRwHxF
ETLTUByT9MAvtNsygVDrLbp
g2i1feALSCwK4teLw2CTBRf
X5lwTHKzEhRtyB3xBWEAVrp
4BnEK6LmHuCkwV4KqyaG1hV
dn5SRVkR53nUj61iLhFREcj
aXTElE2WO5SdGGkaVlZMVzZ
gu0yQVWisHvSvfsmegK8TYu
4O9XOzHSYdsQnhW6OQKcnZp
uBuNrb4zx8IZUn8OUwWk0YI
jNnucs1CJ04u4a9YdcCFKPO
C3do5Ri9SHVzcYOUI00mmg9
GimMTxnUn4Lz3LU4Wzei0//
///////////////////////
///////////////////////
///////';
$data = str_split(base64_decode($data));
$result = '';
foreach ($data as $c) {
    $result .= chr(ord($c) ^ 0xFF);
}
file_put_contents('xor', $result);
