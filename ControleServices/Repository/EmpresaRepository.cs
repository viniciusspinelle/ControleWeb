using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class EmpresaRepository
    {
        public Empresa GetAll(CONTROLEEEntities db, Empresa empresa, JQueryDataTableParamModel param)
        {
            var data = (from E in db.EMPRESA
                        select new Empresa
                        {
                            ID = E.ID,
                            Nome = E.NOME,
                            CPFCNPJ = E.CPFCNPJ,
                            Email = E.EMAIL,
                            Celular = E.CELULAR,
                            Telefone = E.TELEFONE,
                            Endereco = E.ENDERECO,
                            Numero = E.NUMERO,
                            Bairro = E.BAIRRO,
                            Cidade = E.CIDADE,
                            Estado = E.ESTADO,
                            Cep = E.CEP,
                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.Nome.Contains(param.search));
            }

            empresa.Count = data.Count();

            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            empresa.ListaEmpresa = data.ToList();
            return empresa;
        }

        public Empresa GetEmpresa(CONTROLEEEntities db, long Id)
        {
            var _empresa = (from E in db.EMPRESA
                            where E.ID == Id
                            select new Empresa
                            {
                                ID = E.ID,
                                Nome = E.NOME,
                                CPFCNPJ = E.CPFCNPJ,
                                Email = E.EMAIL,
                                Celular = E.CELULAR,
                                Telefone = E.TELEFONE,
                                Endereco = E.ENDERECO,
                                Numero = E.NUMERO,
                                Bairro = E.BAIRRO,
                                Cidade = E.CIDADE,
                                Estado = E.ESTADO,
                                Cep = E.CEP,
                            }).FirstOrDefault();

            return _empresa;
        }

        public List<Empresa> ListEmpresa (CONTROLEEEntities db)
        {
            return (from E in db.EMPRESA
                    select new Empresa
                    {
                        ID = E.ID,
                        Nome = E.NOME,
                    }).ToList();

        }

        //Insert
        public void Insert(CONTROLEEEntities db, Empresa empresa)
        {
            EMPRESA _EMPRESA = new EMPRESA();

            _EMPRESA.NOME = empresa.Nome;
            _EMPRESA.CPFCNPJ = empresa.CPFCNPJ;
            _EMPRESA.EMAIL = empresa.Email;
            _EMPRESA.CELULAR = empresa.Celular;
            _EMPRESA.TELEFONE = empresa.Telefone;
            _EMPRESA.ENDERECO = empresa.Endereco;
            _EMPRESA.NUMERO = empresa.Numero;
            _EMPRESA.BAIRRO = empresa.Bairro;
            _EMPRESA.CIDADE = empresa.Cidade;
            _EMPRESA.ESTADO = empresa.Estado;
            _EMPRESA.CEP = empresa.Cep;

            db.EMPRESA.Add(_EMPRESA);
        }

        public void Update(CONTROLEEEntities db, Empresa empresa)
        {
            var _empresa = (from E in db.EMPRESA
                            where E.ID == empresa.ID
                            select E).FirstOrDefault();

            _empresa.NOME = empresa.Nome;
            _empresa.CPFCNPJ = empresa.CPFCNPJ;
            _empresa.EMAIL = empresa.Email;
            _empresa.CELULAR = empresa.Celular;
            _empresa.TELEFONE = empresa.Telefone;
            _empresa.ENDERECO = empresa.Endereco;
            _empresa.NUMERO = empresa.Numero;
            _empresa.BAIRRO = empresa.Bairro;
            _empresa.CIDADE = empresa.Cidade;
            _empresa.ESTADO = empresa.Estado;
            _empresa.CEP = empresa.Cep;
        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _empresa = (from E in db.EMPRESA
                            where E.ID == Id
                            select E).FirstOrDefault();
            db.EMPRESA.Remove(_empresa);
        }
    }
}
