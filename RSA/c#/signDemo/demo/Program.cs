using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyPairStr = @"<RSAKeyValue><Modulus>18lmL3io599boCL7+8TtTkSYI2b9uLjAfw0t1gndISoLu5w8YmvYLBGUpU/IOwinCrJgRSU69xXtTNXS3K6I2IGdWax+Ts4f7kj1VSXGrjAAyAxUoBMwTry69X9J2bxcHu/dxpMuBLt/Vzh+zRyZWYqCdx/2t8Hbl90ydgA8Urs=</Modulus><Exponent>AQAB</Exponent><P>4W5FYk/SzBENzTVhUL9ari/ekXORavSuOuUKTE6n862SU6pSISb92oq3VbhKzCU8nGNnOG5S6/kVKZ8uXJb4Gw==</P><Q>9QxXAL7exhlzE5+2GKKfIH19ae3WsRQnhC7Q4Ua3he58fklwZhk0kR/ztf1asuBy0IVaLtI6FPOYu5bbkE754Q==</Q><DP>JKksO3rDy1ASsIa31svn0WATkA/9XCmClC1faV15TtWxcE3IoX+X1QyuGBCqiVyc6Mn5pWG7toiBeo1amtAqdQ==</DP><DQ>eaW0kyQtxz3fCMDiTvx77k8dsTZmu+V7cH0lKJBIju5DUxX1/FlK5Thtbczl96LAnI92o4OtXbVH/uf2+36ZQQ==</DQ><InverseQ>AtSDxJ3ZnaM4w1BanyajCXMsQCIHh6VYlmJYmPcZ3gZn9n0GjHrnr7OCm7qT5dmD+pfOvWw1SannKKQfjvmr1g==</InverseQ><D>HUmhi+nliuse5YI6DzbwOoJG3+83mp3Ayr3ALd/S2pB5XTJcY8NdaMXOFg3ZEGIhQetp85iVAzo/pgETiI5L1k8N/QD9nCqqKfpK/fYW+QCIsQ8v47Ww7tQGnSTfyQRMSyO0Qm5YDgZ1yBSgDLdvdlRkK2zxlKXxB2J4KTcKr0E=</D></RSAKeyValue>";

            var provider = new RSACryptoServiceProvider();
            provider.FromXmlString(keyPairStr);

            //使用下行代码重新生成公私钥
            // var privateAndPublicKey = provider.ToXmlString(true);

            var signData = new Dictionary<string, object>();
            signData["name"] = "中文测试";
            signData["orderId"] = "001";
            signData["amount"] = 123;

            //使用私钥生成签名
            var signRst = provider.SignData(Encoding.UTF8.GetBytes(convertoToSignString(signData)), new SHA1CryptoServiceProvider());

            //使用验证公钥签名
            var verify = provider.VerifyData(Encoding.UTF8.GetBytes(convertoToSignString(signData)), new SHA1CryptoServiceProvider(), signRst);

            Console.WriteLine(Convert.ToBase64String(signRst));


            var keyParameters = provider.ExportParameters(false);

            Console.WriteLine(Convert.ToBase64String(keyParameters.Modulus));
            Console.WriteLine("------");
            Console.WriteLine(Convert.ToBase64String(keyParameters.Exponent));

            //加密在java端使用公钥加密的数据
            var enctrpted = Convert.FromBase64String("jHj/kLDp3DO5JFNmzMG3L8eREg/W25VQDl8Z+skaER/RQNqvwhe3SFa7VHD64hPBTKhghxoXTbhm0xH/ViZDOVltPRWHBesyE2O6bNnvZ43XVtnGSZ7ub5gHkGp6E0ghngTsycatJDGMyI2VjEoD7RfZC4R+ICo8Dw2fWkNxlA0=");
            var plaintext = provider.Decrypt(enctrpted,false);

            Console.WriteLine(Encoding.UTF8.GetString(plaintext));
            Console.Read();
        }

        public static string convertoToSignString(IDictionary<string, object> dic)
        {
            if (dic == null || dic.Count == 0)
            {
                return null;
            }

            var signStr = new StringBuilder();

            var keys = dic.Keys.ToList();
            keys.Sort();

            foreach (var k in keys)
            {
                signStr.Append(k).Append("=").Append(dic[k]).Append("&");
            }

            signStr.Remove(signStr.Length - 1, 1);

            return signStr.ToString();

        }


    }
}
