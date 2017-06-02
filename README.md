# AES_Encry_Decry_js_go
AES加密解密之使用node.js 和 go lang

AES加密在不同语言需要交互的情况下， 由于不同语言有不同的默认设置， 因此默认是不能通用的加密解密的， 本示例包含了node.js 和 go lang两种语言的加解密方法。

其中node.js的padding默认就使用的是PKCS5， 故在go lang中也使用了同样的padding

# RSA非对称加密的c#与java的互操作

RSA非对称加密算法中，常用使用方式为公钥加密然后私钥解密，另外一种使用方式为私钥生成签名，公钥验签。
本次提交代码中包含有c#与java对这两种使用方式的具体实现。