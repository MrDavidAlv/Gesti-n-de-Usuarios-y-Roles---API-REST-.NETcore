using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Interfaces.Service;
using System.Security.Cryptography;
using System.Text;

namespace empleadosFYMtech.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
            usuario.password = EncryptPassword(usuario.password);
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
            string decryptedPassword = Decrypt(user.password);
            return decryptedPassword == password;
        }

        private string EncryptPassword(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetAesKey();
                aesAlg.IV = GetAesIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(password);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private string Decrypt(string encryptedPassword)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetAesKey();
                aesAlg.IV = GetAesIV();

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        private byte[] GetAesKey()
        {
            var key = _configuration["Encryption:Key"];
            if (string.IsNullOrEmpty(key) || (key.Length != 16 && key.Length != 24 && key.Length != 32))
            {
                throw new CryptographicException("Specified key is not a valid size for this algorithm.");
            }
            return Encoding.UTF8.GetBytes(key);
        }

        private byte[] GetAesIV()
        {
            var iv = _configuration["Encryption:IV"];
            if (string.IsNullOrEmpty(iv) || iv.Length != 16)
            {
                throw new CryptographicException("Specified IV is not a valid size for this algorithm.");
            }
            return Encoding.UTF8.GetBytes(iv);
        }
    }
}
