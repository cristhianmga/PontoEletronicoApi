using Microsoft.EntityFrameworkCore;
using PontoEletronico.Data;
using System.Collections.Generic;
using System.Linq;

namespace PontoEletronico.Servico.Base
{
    public class BaseServico
    {
        private readonly ApplicationDbContext _ctx;

        public BaseServico(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public E Salvar<E>(E entidade) where E : class
        {
            _ctx.Add(entidade);
            _ctx.SaveChanges();
            return entidade;

        }


        public virtual IQueryable<E> ObterTodos<E>(IEnumerable<string> includes = null) where E : class
        {
            IQueryable<E> result = _ctx.Set<E>().AsQueryable();
            if (includes != null)
            {
                foreach (string i in includes)
                {
                    result = result.Include(i);
                }
                return result;
            }
            else return result;
        }



        public virtual E Obter<E>(int id, IEnumerable<string> includes = null) where E : class
        {
            IQueryable<E> result = _ctx.Set<E>().AsQueryable();
            if (includes != null)
            {
                foreach (string i in includes)
                {
                    result.Include(i);
                }
                return result.WhereEquals("id",id).FirstOrDefault();
            }

            else return result.WhereEquals("id",id).FirstOrDefault();
        }



        public void ExcluirAsync<E>(int id) where E : class
        {
            _ctx.Set<E>().Remove(_ctx.Set<E>().Find(id));
            _ctx.SaveChangesAsync();
        }



        public void Atualizar<E>(dynamic entidade, IEnumerable<string> properties = null) where E : class
        {
            if (properties == null)
            {
                _ctx.Update(entidade);
            }
            else
            {
                #warning Consertar esse erro
                //_ctx.Set<E>().Attach(entidade);
                //_ctx.Entry(entidade).State = EntityState.Unchanged;

                //foreach (var property in properties)
                //{
                //    _ctx.Entry<E>(entidade).Property(ExpressionHelper.GetExpressionText(property)).IsModified = true;
                //}
            }
            _ctx.SaveChanges();
        }
    }
}
