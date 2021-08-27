using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class TelefoneClienteRepository
    {

        public void Insert(CONTROLEEEntities db, TelefoneCliente telefoneCliente)
        {
            TELEFONE_CLIENTE _TELEFONECLIENTE = new TELEFONE_CLIENTE();

            _TELEFONECLIENTE.ID_CLIENTE = telefoneCliente.ID_Cliente;
            _TELEFONECLIENTE.TELEFONE = telefoneCliente.Telefone;
            _TELEFONECLIENTE.RESPONSAVEL = telefoneCliente.Responsavel;
            _TELEFONECLIENTE.PRINCIPAL = telefoneCliente.Principal;

            db.TELEFONE_CLIENTE.Add(_TELEFONECLIENTE);
            db.SaveChanges();
        }

        public bool Exist(CONTROLEEEntities db, long Id)
        {
            var _telefone = (from TC in db.TELEFONE_CLIENTE
                            where TC.ID == Id 
                            select TC).FirstOrDefault();

            return _telefone == null ? false : true;
        }

        public List<TelefoneCliente> ListTelefone(CONTROLEEEntities db, long Id)
        {
            var _telefone = (from TC in db.TELEFONE_CLIENTE
                            where TC.ID_CLIENTE == Id
                            select new TelefoneCliente
                            {
                              ID_Cliente = TC.ID_CLIENTE,
                              ID= TC.ID,
                              Telefone= TC.TELEFONE,
                              Principal= TC.PRINCIPAL,
                              Responsavel= TC.RESPONSAVEL,
                            }).ToList();

            return _telefone;

        }



        public void Update(CONTROLEEEntities db, TelefoneCliente telefone)
        {
            var _telefone = (from TC in db.TELEFONE_CLIENTE
                            where TC.ID == telefone.ID
                            select TC).FirstOrDefault();

            _telefone.ID_CLIENTE = telefone.ID_Cliente;
            _telefone.TELEFONE = telefone.Telefone;
            _telefone.RESPONSAVEL = telefone.Responsavel;
            _telefone.PRINCIPAL = telefone.Principal;          
            
        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _telefone = (from TC in db.TELEFONE_CLIENTE
                             where TC.ID == Id
                             select TC).FirstOrDefault();

            db.TELEFONE_CLIENTE.Remove(_telefone);
        }
    }
}
