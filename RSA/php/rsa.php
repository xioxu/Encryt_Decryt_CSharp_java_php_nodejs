<?php

$phpsecLibPath = dirname(__FILE__) .  '/phpseclib';
set_include_path($phpsecLibPath);
include('Crypt/RSA.php');

$privatekey = "<RSAKeyValue><Modulus>18lmL3io599boCL7+8TtTkSYI2b9uLjAfw0t1gndISoLu5w8YmvYLBGUpU/IOwinCrJgRSU69xXtTNXS3K6I2IGdWax+Ts4f7kj1VSXGrjAAyAxUoBMwTry69X9J2bxcHu/dxpMuBLt/Vzh+zRyZWYqCdx/2t8Hbl90ydgA8Urs=</Modulus><Exponent>AQAB</Exponent><P>4W5FYk/SzBENzTVhUL9ari/ekXORavSuOuUKTE6n862SU6pSISb92oq3VbhKzCU8nGNnOG5S6/kVKZ8uXJb4Gw==</P><Q>9QxXAL7exhlzE5+2GKKfIH19ae3WsRQnhC7Q4Ua3he58fklwZhk0kR/ztf1asuBy0IVaLtI6FPOYu5bbkE754Q==</Q><DP>JKksO3rDy1ASsIa31svn0WATkA/9XCmClC1faV15TtWxcE3IoX+X1QyuGBCqiVyc6Mn5pWG7toiBeo1amtAqdQ==</DP><DQ>eaW0kyQtxz3fCMDiTvx77k8dsTZmu+V7cH0lKJBIju5DUxX1/FlK5Thtbczl96LAnI92o4OtXbVH/uf2+36ZQQ==</DQ><InverseQ>AtSDxJ3ZnaM4w1BanyajCXMsQCIHh6VYlmJYmPcZ3gZn9n0GjHrnr7OCm7qT5dmD+pfOvWw1SannKKQfjvmr1g==</InverseQ><D>HUmhi+nliuse5YI6DzbwOoJG3+83mp3Ayr3ALd/S2pB5XTJcY8NdaMXOFg3ZEGIhQetp85iVAzo/pgETiI5L1k8N/QD9nCqqKfpK/fYW+QCIsQ8v47Ww7tQGnSTfyQRMSyO0Qm5YDgZ1yBSgDLdvdlRkK2zxlKXxB2J4KTcKr0E=</D></RSAKeyValue>";
$publickey = "<RSAKeyValue><Modulus>18lmL3io599boCL7+8TtTkSYI2b9uLjAfw0t1gndISoLu5w8YmvYLBGUpU/IOwinCrJgRSU69xXtTNXS3K6I2IGdWax+Ts4f7kj1VSXGrjAAyAxUoBMwTry69X9J2bxcHu/dxpMuBLt/Vzh+zRyZWYqCdx/2t8Hbl90ydgA8Urs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

$rsa = new Crypt_RSA();
$rsa->loadKey($publickey);

$plaintext = 'zzz';
//define('CRYPT_RSA_PKCS15_COMPAT', true);

$rsa->setEncryptionMode(CRYPT_RSA_ENCRYPTION_PKCS1);


//php 加密
$encrpted = base64_encode($rsa->encrypt($plaintext));

$ciphertext =base64_decode($encrpted);

//php解密
$rsa->loadKey($privatekey);
$plaintext = $rsa->decrypt($ciphertext);
echo $plaintext;

//.net/java rsa 密文
$ciphertext = "jHj/kLDp3DO5JFNmzMG3L8eREg/W25VQDl8Z+skaER/RQNqvwhe3SFa7VHD64hPBTKhghxoXTbhm0xH/ViZDOVltPRWHBesyE2O6bNnvZ43XVtnGSZ7ub5gHkGp6E0ghngTsycatJDGMyI2VjEoD7RfZC4R+ICo8Dw2fWkNxlA0=";


$ciphertext =base64_decode(($ciphertext));
$rsa->loadKey($privatekey);
//define('CRYPT_RSA_PKCS15_COMPAT', true);
//$rsa->setEncryptionMode(CRYPT_RSA_ENCRYPTION_PKCS1);
$plaintext = $rsa->decrypt($ciphertext);

echo "\r\n" . $plaintext;