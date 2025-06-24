using Anotacoes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes.Database.Repositories {
    public static class RegistroRepository {

        public static List<Registro> BuscarRegistros () {
            using (var banco = new AppDbContext()) {
                return banco.Registros.OrderByDescending(x => x.Id).ToList();
            }
        }

        public static void AdicionarRegistro (Registro registro) {
            using (var banco = new AppDbContext()) {
                banco.Registros.Add(registro);
                banco.SaveChanges();
            }
        }

        public static Registro BuscarRegistroPorID (int id) {
            using (var banco = new AppDbContext()) {
                return banco.Registros.FirstOrDefault(x => x.Id == id);
            }
        }
        
        public static void AtualizarRegistro (Registro registro) {
            using (var banco = new AppDbContext()) {
                var registroExistente = banco.Registros.FirstOrDefault(x => x.Id == registro.Id);
                if (registroExistente != null) {
                    registroExistente.Name = registro.Name;
                    registroExistente.Comment = registro.Comment;
                    banco.SaveChanges();
                }
            }
        }

        public static void ApagarRegistro(int id) {
            using (var banco = new AppDbContext()) {
                var registro = banco.Registros.FirstOrDefault(x => x.Id == id);
                if (registro != null) {
                    banco.Registros.Remove(registro);
                    banco.SaveChanges();
                }
            }
        }   
    }
}
