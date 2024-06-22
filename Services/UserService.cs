using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Interfaces.Service;
using System.Security.Cryptography;
using System.Text;

namespace empleadosFYMtech.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            //_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userRepository = userRepository;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _userRepository.GetUsuariosAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {

            return await _userRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            usuario.password = EncryptPassword(usuario.password);

            return await _userRepository.CrearUsuarioAsync(usuario);
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, Usuario usuario)
        {
            return await _userRepository.ActualizarUsuarioAsync(id, usuario);
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            return await _userRepository.EliminarUsuarioAsync(id);
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<bool> ValidatePasswordAsync(Usuario user, string password)
        {
            // Aquí implementa la lógica para desencriptar la contraseña guardada y compararla con la contraseña proporcionada
            string decryptedPassword = Decrypt(user.password);
            return decryptedPassword == password;
        }

        private string EncryptPassword(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Debes almacenar la clave y el IV de manera segura y fuera del código en un entorno real
                aesAlg.Key = Encoding.UTF8.GetBytes("9283665895033192"); // 32 bytes para AES-256
                aesAlg.IV = Encoding.UTF8.GetBytes("4626515105087167"); // 16 bytes para AES

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = null;

                // Cifrar el texto
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        private string Decrypt(string encryptedPassword)
        {
            // Implementa aquí la lógica de desencriptación con AES
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedPassword);
            string key = "tu clave de cifrado"; //Key de cifrado
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];
                using (MemoryStream ms = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }


        }
    }
}
