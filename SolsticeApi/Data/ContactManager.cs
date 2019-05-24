using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolsticeApi.Models;
using SolsticeApi.Models.Repository;

namespace SolsticeApi.Data.ContactManager
{
    public class ContactManager : IDataRepository<Contact>
    {
        readonly ContactContext _ContactContext;

        public ContactManager(ContactContext context)
        {
            _ContactContext = context;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _ContactContext.Contacts.ToList();
        }

        public Contact GetContactById(long id)
        {
            return _ContactContext.Contacts
                  .FirstOrDefault(e => e.Id == id);
        }

        public List<Contact> GetAllContactsByStateOrAdress(string value)
        {
            return _ContactContext.Contacts.Where(s => s.City.ToLower().Contains(value.ToLower()) || s.Country.ToLower().Contains(value.ToLower())).ToList<Contact>();
        }


        public Contact GetContactByEmailOrPhone(string value)
        {
            return _ContactContext.Contacts.FirstOrDefault(s => s.Email.ToLower().Contains(value.ToLower()) || s.PhonePersonal.ToLower().Contains(value.ToLower()) || s.PhoneWork.ToLower().Contains(value.ToLower()));
        }



        public Contact PostNewContact(Contact entity)
        {
            Contact NewContact = new Contact();

            NewContact = _ContactContext.Contacts.Add(entity).Entity;
            _ContactContext.SaveChanges();

            return NewContact;
        }

        public Contact Update(Contact contact, Contact entity)
        {
            contact.Name = entity.Name;
            contact.Company = entity.Company;
            contact.Email = entity.Email;
            contact.BirthDate = entity.BirthDate;
            contact.PhonePersonal = entity.PhonePersonal;
            contact.PhoneWork = entity.PhoneWork;
            contact.Street = entity.Street;
            contact.City = entity.City;
            contact.Country = entity.Country;
            contact.PictureURL = entity.PictureURL;

            _ContactContext.SaveChanges();

            return contact;
        }

        public void Delete(Contact employee)
        {
            _ContactContext.Contacts.Remove(employee);
            _ContactContext.SaveChanges();
        }


    }
}