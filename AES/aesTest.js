var crypto=require('crypto');
var SecKey="09414ec0b5654a5f8f5becccc25a3274";//º”√‹µƒ√ÿ‘ø

 var iv = SecKey.substr(0,16);

var cryptFunc = function(text){
  /*  var cipher=  crypto.createCipheriv('rc4',SecKey,iv);
	cipher.setAutoPadding(true)
    var crypted =cipher.update(text,'utf8','base64');
     crypted+=cipher.final('base64');
	 
	 return crypted;*/
	// return  CryptoJS.AES.encrypt(text, SecKey, { mode: CryptoJS.mode.CBC, padding: CryptoJS.pad.ZeroPadding }).toString();
	
	var cipher=  crypto.createCipheriv('aes-256-cbc',SecKey,iv);
	 
    var crypted =cipher.update(text,'utf8','base64');
     crypted+=cipher.final('base64');
	 
	 return crypted;
};

//Ω‚√‹
function decipher(encrypted){
  /*  var decrypted = "";
    var decipher = crypto.createCipheriv('rc4', SecKey,iv);
	decipher.setAutoPadding(true)
    decrypted += decipher.update(encrypted, 'base64', 'binary');
    decrypted += decipher.final('binary');
    return decrypted;*/
	// return  CryptoJS.AES.decrypt(encrypted, SecKey, { mode: CryptoJS.mode.CBC, padding: CryptoJS.pad.ZeroPadding }).toString(CryptoJS.enc.Utf8);
	
	 var decrypted = "";
    var decipher = crypto.createDecipheriv('aes-256-cbc', SecKey,iv);
	 
    decrypted += decipher.update(encrypted, 'base64', 'binary');
    decrypted += decipher.final('binary');
    return decrypted;
}

var encryVal = cryptFunc("polaris@studygolang",SecKey);
console.log("polaris@studygolang");
console.log(encryVal);
console.log("-----");
console.log(decipher(encryVal));