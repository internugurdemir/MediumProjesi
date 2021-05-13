//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProjectMedium.Models.DataAccess.Repositories
//{
//    /*
//     * Generic dizaynlar:
//     *      Ekle Sil Günceelle tekrarından kurtulmak için aslında
//     *      Ekle, sil, Güncelle, getir, Listele... Daha büyük şirketlerde, projelerde daha fazla Add, rremove, delete...
//     *      Dha Düzgün Yönetim için...
//     */
//    public class GenericRepository<T> where T:class, new() //gelen T mutlaka class olmalı ve new barındırmalı
//    {


//        MediumDbContext context = new MediumDbContext();
//        public GenericRepository(MediumDbContext ctx)
//        {
//            context = ctx;
//            //boostDbContext = new BoostDbContext();
//        }
//        public List<T> TListBynInt()
//        {
//            return context.Set<T>().ToList();
//        }
//        public void TAddBynInt(T t)
//        {
//            context.Set<T>().Add(t);
//            context.SaveChanges();
//        }
//        public void TRemoveBynInt(T t)
//        {
//            context.Set<T>().Remove(t);
//            context.SaveChanges();
//        }
//        public void TUpdateBynInt(T t)
//        {
//            context.Set<T>().Update(t);
//            context.SaveChanges();
//        }
//        public void TGetByint(int id)
//        {
//            context.Set<T>().Find(id);
//        }
//        public List<T> TListBynInt(string p)
//        {
//            return context.Set<T>().Include(p).ToList();
//        }
//    }
//}
