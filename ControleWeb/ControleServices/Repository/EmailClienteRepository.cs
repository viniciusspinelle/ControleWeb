using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ControleServices.Repository
{
    public class EmailClienteRepository
    {
        public void Insert(CONTROLEEEntities db, EmailCliente emailCliente)
        {
            EMAIL_CLIENTE _EMAILCLIENTE = new EMAIL_CLIENTE();

            _EMAILCLIENTE.ID_CLIENTE = emailCliente.ID_Cliente;
            _EMAILCLIENTE.EMAIL = emailCliente.Email;
            _EMAILCLIENTE.PRINCIPAL = emailCliente.Principal;

            db.EMAIL_CLIENTE.Add(_EMAILCLIENTE);
        }


        public List<EmailCliente> ListEmail(CONTROLEEEntities db, long Id)
        {
            var _email = (from EC in db.EMAIL_CLIENTE
                             where EC.ID_CLIENTE == Id
                             select new EmailCliente
                             {
                                 ID_Cliente = EC.ID_CLIENTE,
                                 ID = EC.ID,
                                 Email=EC.EMAIL,
                                 Principal = EC.PRINCIPAL,                                 
                             }).ToList();

            return _email;

        }

        public bool Exist(CONTROLEEEntities db, long Id)
        {
            var _telefone = (from TC in db.EMAIL_CLIENTE
                            where TC.ID == Id 
                            select TC).FirstOrDefault();

            return _telefone == null ? false : true;
        }

        public void Update(CONTROLEEEntities db, EmailCliente email)
        {
            var _email = (from EC in db.EMAIL_CLIENTE
                             where EC.ID == email.ID
                             select EC).FirstOrDefault();

            _email.ID_CLIENTE = email.ID_Cliente;
            _email.EMAIL = email.Email;
            _email.PRINCIPAL = email.Principal;
        }

        public void Delete(CONTROLEEEntities db, long Id)
        {
            var _email = (from EC in db.EMAIL_CLIENTE
                             where EC.ID == Id
                             select EC).FirstOrDefault();

            db.EMAIL_CLIENTE.Remove(_email);
        }
    }
}
