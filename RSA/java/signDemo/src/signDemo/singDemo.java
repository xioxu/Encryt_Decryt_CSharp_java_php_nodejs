package signDemo;

import java.io.UnsupportedEncodingException;
import java.math.BigInteger;
import java.security.GeneralSecurityException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PublicKey;
import java.security.Signature;
import java.security.spec.RSAPublicKeySpec;
import java.util.Base64;
import java.util.Base64.Decoder;

import javax.crypto.Cipher;
import javax.crypto.NoSuchPaddingException;

public class singDemo {

	public static void main(String args[]) throws Exception {
		//待加密数据
		String someString = "amount=123&name=中文测试&orderId=001";
		
		//。net端使用私钥生成的签名
		String signature = "DZM+uSO2SzhapmhQTSPmOpRSa1OK3zvUq6ZmtwhJeg0MI+6FlibF1eiJMN/EyuvzhBfs+MsXtEZKPeGqTU8xPgAIACxVcM8BAdRk7gAxj8UmMYSIxCyLhWOfAQ6XGRsQX8srHpkQxm0uLb7+A1qiGqiDEsxmu/wm13O5ZERdN/Q=";
		
		
		String modulus = "18lmL3io599boCL7+8TtTkSYI2b9uLjAfw0t1gndISoLu5w8YmvYLBGUpU/IOwinCrJgRSU69xXtTNXS3K6I2IGdWax+Ts4f7kj1VSXGrjAAyAxUoBMwTry69X9J2bxcHu/dxpMuBLt/Vzh+zRyZWYqCdx/2t8Hbl90ydgA8Urs=";
		String exponent = "AQAB";
		Decoder decoder = Base64.getDecoder();
		
		BigInteger BIModulus = new BigInteger(1, decoder.decode(modulus));
		BigInteger BIExponent = new BigInteger(1, decoder.decode(exponent));

		RSAPublicKeySpec publicKeySpec = new RSAPublicKeySpec(BIModulus, BIExponent);
		
		PublicKey publicKey = KeyFactory.getInstance("RSA").generatePublic(publicKeySpec);
		Signature sign = Signature.getInstance("SHA1withRSA");
		sign.initVerify(publicKey);
		sign.update(someString.getBytes("utf-8"));
		
		//验证签名
		boolean ok = sign.verify(decoder.decode(signature));
		
		System.out.println("Verify Result:" + ok);
		
		//使用公钥加密
		System.out.println("Encrypt val:" + encrypt("hello",publicKey));

	  }
	
	private static String encrypt(String plainTextData,PublicKey publicKey) throws NoSuchAlgorithmException, GeneralSecurityException, UnsupportedEncodingException{
		Cipher cipher = null;  
		 // 使用默认RSA  
        cipher = Cipher.getInstance("RSA/ECB/PKCS1Padding");  
        // cipher= Cipher.getInstance("RSA", new BouncyCastleProvider());  
        cipher.init(Cipher.ENCRYPT_MODE, publicKey);  
        byte[] output = cipher.doFinal(plainTextData.getBytes("utf-8"));

        return Base64.getEncoder().encodeToString(output);
	}

	   

}
