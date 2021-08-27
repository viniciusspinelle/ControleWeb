using ControleServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
//teste
namespace ControleServices.Business
{
    public class ClienteBusiness
    {
        ClienteRepository _clienteRepository = new ClienteRepository();
        TelefoneClienteRepository _telefoneClienteRepository = new TelefoneClienteRepository();
        EmailClienteRepository _emailClienteRepository = new EmailClienteRepository();
        ProjetoRepository _projetoRepository = new ProjetoRepository();

        TelefoneCliente _telefone = new TelefoneCliente();
        EmailCliente _email = new EmailCliente();


        public Cliente GetAll(Cliente cliente, JQueryDataTableParamModel param)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                Cliente _cliente = new Cliente();
                _cliente = _clienteRepository.GetAll(db, cliente, param);
                return _cliente;

            }
        }


        public Cliente GetCliente(long Id)
        {

            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                Cliente _cliente = new Cliente();

                if (Id != 0)
                {
                    _cliente = _clienteRepository.GetCliente(db, Id);
                    _cliente.ListaProjeto = _projetoRepository.ListProjeto(db);
                    _cliente.ListaTelefone = _telefoneClienteRepository.ListTelefone(db, Id);
                    _cliente.ListaEmail = _emailClienteRepository.ListEmail(db, Id);

                }
                else
                {
                    _cliente.ListaProjeto = _projetoRepository.ListProjeto(db);

                }
                return _cliente;
            }

        }


        public Cliente AlterCliente(Cliente cliente)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                CLIENTE _Cliente = new CLIENTE();

                if (cliente.ID == 0)
                {

                    _Cliente = _clienteRepository.Insert(db, cliente);

                    //Foreach Telefone 
                    foreach (var item in cliente.ListaTelefone.Where(c => c.ID == 0).ToList())
                    {
                        _telefone.ID_Cliente = _Cliente.ID;
                        _telefone.Telefone = item.Telefone;
                        _telefone.Principal = item.Principal;
                        _telefone.Responsavel = item.Responsavel;

                        _telefoneClienteRepository.Insert(db, _telefone);
                    }

                    //Foreach Email
                    foreach (var item in cliente.ListaEmail.Where(c => c.ID == 0).ToList())
                    {
                        _email.ID_Cliente = _Cliente.ID;
                        _email.Email = item.Email;
                        _email.Principal = item.Principal;

                        _emailClienteRepository.Insert(db, _email);
                    }

                }
                else
                {
                    _clienteRepository.Update(db, cliente);

                    //TELEFONE 
                    _telefone.ListFone = _telefoneClienteRepository.ListTelefone(db, cliente.ID); //Lista os Telefones do Banco

                    foreach (var item in _telefone.ListFone) // Percorrer a  Lista fone 
                    {
                        if (cliente.ListaTelefone != null)
                        {
                            var ExistTelefone = cliente.ListaTelefone.Where(t => t.ID == item.ID).FirstOrDefault();// Verifica se exite um telefone na lista fone 

                            if (ExistTelefone == null) // Se null chama a função para deletar 
                            {
                                _telefoneClienteRepository.Delete(db, item.ID);
                            }
                        }
                        else
                        {
                            _telefoneClienteRepository.Delete(db, item.ID);
                        }
                    }

                    if (cliente.ListaTelefone != null)
                    {
                        foreach (var T in cliente.ListaTelefone)
                        {
                            if (T.ID != 0)
                            {
                                _telefone.ID = T.ID;
                                _telefone.ID_Cliente = cliente.ID;
                                _telefone.Telefone = T.Telefone;
                                _telefone.Principal = T.Principal;
                                _telefone.Responsavel = T.Responsavel;
                                _telefoneClienteRepository.Update(db, _telefone);
                            }
                            else
                            {
                                _telefone.ID_Cliente = cliente.ID;
                                _telefone.Telefone = T.Telefone;
                                _telefone.Principal = T.Principal;
                                _telefone.Responsavel = T.Responsavel;
                                _telefoneClienteRepository.Insert(db, _telefone);
                            }
                        }
                    }
                    //FIM TELEFONE 

                    //LISTA EMAIL 

                    _email.ListEmail = _emailClienteRepository.ListEmail(db, cliente.ID); //Lista os Email do Banco


                    foreach (var item in _email.ListEmail) // Percorrer a  Lista fone 
                    {
                        if (cliente.ListaEmail != null)
                        {
                            var ExistEmail = cliente.ListaEmail.Where(t => t.ID == item.ID).FirstOrDefault();// Verifica se exite um email na lista Email

                            if (ExistEmail == null) // Se null chama a função para deletar 
                            {
                                _emailClienteRepository.Delete(db, item.ID);
                            }
                        }
                        else
                        {
                            _emailClienteRepository.Delete(db, item.ID);
                        }
                    }

                    if (cliente.ListaEmail != null)
                    {
                        foreach (var E in cliente.ListaEmail)
                        {
                            if (E.ID != 0)
                            {
                                _email.ID = E.ID;
                                _email.ID_Cliente = cliente.ID;
                                _email.Email = E.Email;
                                _email.Principal = E.Principal;

                                _emailClienteRepository.Update(db, _email);
                            }
                            else
                            {
                                _email.ID_Cliente = cliente.ID;
                                _email.Email = E.Email;
                                _email.Principal = E.Principal;

                                _emailClienteRepository.Insert(db, _email);
                            }
                        }
                    }
                }
                db.SaveChanges();

            }
            return cliente;
        }


        public void RemoveCliente(long Id)
        {
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
                try
                {
                    _telefone.ListFone = _telefoneClienteRepository.ListTelefone(db, Id);
                    foreach(var item in _telefone.ListFone)
                    {
                        if(item.ID_Cliente == Id)
                        {
                            _telefoneClienteRepository.Delete(db, item.ID);
                        }
                    }
                    _email.ListEmail = _emailClienteRepository.ListEmail(db, Id);
                    foreach (var item in _email.ListEmail)
                    {
                        if (item.ID_Cliente == Id)
                        {
                            _emailClienteRepository.Delete(db, item.ID);
                        }
                    }
                    _clienteRepository.Delete(db, Id);
                    db.SaveChanges();
                }
                catch (SqlException ex)
                {
                }
            }

        }

        public List<Cliente> getCliente(string cliente)
        {
           
            using (CONTROLEEEntities db = new CONTROLEEEntities())
            {
         
               return _clienteRepository.getListCliente(db, cliente);
                
            }


        }
    }
}
