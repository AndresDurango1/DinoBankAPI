using DinoBank.Domain.User;
using Newtonsoft.Json;

namespace DinoBank.Persistence.Database
{
    public class DatabaseService : IDatabaseService
    {
        private static string route = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "DinoBank.Persistence", "Files");

        //Metodo para obtener toda la informacipon de los usuarios del JSON
        public List<UserEntity> GetAll()
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserEntity>>(json) ?? new List<UserEntity>();
            }
        }
        //Metodo para crear un nuevo usuario en el JSON
        public bool Create(UserEntity user)
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                r.Close();
                var listUser = JsonConvert.DeserializeObject<List<UserEntity>>(json) ?? new List<UserEntity>();
                user.Id = listUser.Count + 1;
                listUser.Add(user);
                json = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                File.WriteAllText(file, json);
                return true;
            }
        }
        //Metodo para actualizar un usuario en el JSON
        public bool Update(UserEntity user)
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                r.Close();
                var listUser = JsonConvert.DeserializeObject<List<UserEntity>>(json);
                if (listUser == null || listUser.Count == 0)
                {
                    return false;
                }
                var index = listUser.FindIndex(x => x.Id == user.Id);
                if (index != -1)
                {
                    listUser[index] = user;
                    json = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                    File.WriteAllText(file, json);
                    return true;
                }
                return false;
            }
        }
        //Metodo para eliminar un usuario del JSON
        public bool Delete(int id)
        {
            var file = Path.Combine(route, "User.JSON");
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                r.Close();
                var listUser = JsonConvert.DeserializeObject<List<UserEntity>>(json);
                if (listUser == null || listUser.Count == 0)
                {
                    return false;
                }
                bool remove = listUser.RemoveAll(x => x.Id == id) > 0;
                if (remove)
                {
                    json = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                    File.WriteAllText(file, json);
                }
                return remove;
            }
        }
    }
}
