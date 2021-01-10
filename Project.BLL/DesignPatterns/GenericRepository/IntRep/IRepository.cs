using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {
        //Listeleme Islemleri (List Commands)
        List<T> GetAll(); //Hepsini listeleme
        List<T> GetActives(); //Aktif olanlari listeleme
        List<T> GetPassives(); // Pasif olanlari listeleme
        List<T> GetModifieds(); //Guncellenenleri listeleme

        //Guncelleme Islemleri(Modifieds Commands)
        void Add(T item); //Tek ekleme
        void AddRange(List<T> item); //Birden fazla (Coklu ekleme)
        void Delete(T item); //Tek silme
        void DeleteRange(List<T> item); // Coklu Silme
        void Destroy(T item);//Tek ortadan kaldirma
        void DestroyRange(List<T> item); //Coklu ortadan kaldirma
        void Update(T item); //Tekli guncelleme
        void UpdateRange(List<T> item); //Coklu guncelleme

        //Expression Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);

        //Find Commands
        T Find(int id);
    }
}
