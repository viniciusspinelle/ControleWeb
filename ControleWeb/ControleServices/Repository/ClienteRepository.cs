using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ControleServices.Repository
{
    public class ClienteRepository
    {
        public Cliente GetAll(CONTROLEEEntities db, Cliente cliente, JQueryDataTableParamModel param)
        {
            var data = (from C in db.CLIENTE
                        join P in db.PROJETO on C.ID_PROJETO equals P.ID
                        select new Cliente
                        {
                            ID = C.ID,
                            RazaoSocial = C.RAZAOSOCIAL,
                            ProjetoDescricao = P.DESCRICAO,
                            CPFCNPJ = C.CPFCNPJ,

                        }).ToList();

            if (param.search != null)
            {
                data.Where(c => c.RazaoSocial.Contains(param.search));
            }
            cliente.Count = data.Count();


            var query = param.length != 0 ? data.Skip(param.start).Take(param.length) : data;

            cliente.ListaCliente = data.ToList();


            return cliente;
        }

        public Cliente GetCliente(CONTROLEEEntities db, long Id)
        {
            var _cliente = (from C in db.CLIENTE
                            where C.ID == Id
                            select new Cliente
                            {   
                                ID= C.ID,
                                ID_Projeto = C.ID_PROJETO,                            
                                RazaoSocial = C.RAZAOSOCIAL,
                                CPFCNPJ = C.CPFCNPJ,
                                NomeFantasia = C.NOME_FANTASIA,
                                Contato = C.CONTATO,
                                Endereco=C.ENDERECO,
                                Numero=C.NUMERO,
                                Bairro=C.BAIRRO,
                                Cidade=C.CIDADE,
                                Estado=C.ESTADO,
                                CEP=C.CEP


                            }).FirstOrDefault();

            return _cliente;

        }

        public List<Cliente> getListCliente(CONTROLEEEntities db, string cliente)
        {
            var data = (from C in db.CLIENTE
                        where C.RAZAOSOCIAL.Contains(cliente)
                        select new Cliente
                        {
                            ID = C.ID,
                            RazaoSocial = C.RAZAOSOCIAL,

                        }).ToList();
            return data;
        }


        //Insert
        public CLIENTE Insert(CONTROLEEEntities db, Cliente cliente)
        {
            CLIENTE _CLIENTE = new CLIENTE();

            _CLIENTE.ID_PROJETO = cliente.ID_Projeto;
            _CLIENTE.RAZAOSOCIAL = cliente.RazaoSocial;
            _CLIENTE.CPFCNPJ = cliente.CPFCNPJ;
            _CLIENTE.NOME_FANTASIA = cliente.NomeFantasia;
            _CLIENTE.CONTATO = cliente.Contato;
            _CLIENTE.ENDERECO = cliente.Endereco;
            _CLIENTE.NUMERO = cliente.Numero;
            _CLIENTE.BAIRRO = cliente.Bairro;
            _CLIENTE.ESTADO = cliente.Estado;
            _CLIENTE.CIDADE = cliente.Cidade;
            _CLIENTE.CEP = cliente.CEP;

            db.CLIENTE.Add(_CLIENTE);
            db.SaveChanges();
            return _CLIENTE;
        }

        public void Update(CONTROLEEEntities db, Cliente cliente)
        {
            var _cliente = (from C in db.CLIENTE
                            where C.ID == cliente.ID
                            select C).FirstOrDefault();

            _cliente.ID_PROJETO = cliente.ID_Projeto;
            _cliente.RAZAOSOCIAL = cliente.RazaoSocial;
            _cliente.CPFCNPJ = cliente.CPFCNPJ;
            _cliente.NOME_FANTASIA = cliente.NomeFantasia;
            _cliente.CONTATO = cliente.Contato;
            _cliente.ENDERECO = cliente.Endereco;
            _cliente.NUMERO = cliente.Numero;
            _cliente.CIDADE = cliente.Cidade;
            _cliente.BAIRRO = cliente.Bairro;
            _cliente.ESTADO = cliente.Estado;
            _cliente.CEP = cliente.CEP;


        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _cliente = (from C in db.CLIENTE
                            where C.ID == Id
                            select C).FirstOrDefault();
            db.CLIENTE.Remove(_cliente);
        }
    }
}
