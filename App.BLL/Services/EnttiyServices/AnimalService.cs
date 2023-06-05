using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using App.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using App.DAL.Repositories;
using App.DAL.DataContext;

namespace App.BLL.Services.EnttiyServices
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalRepository _repo;

 
        public AnimalService(DbPetsContext repo)
        {
            _repo = new AnimalRepository(repo);
        }

        public IEnumerable<Animal> GetAnimalByCatgory(int Catogoryid, IEnumerable<Animal> animals)
        {
            if (animals == null)
                animals = _repo.GetAll();

           return animals.Where(animals => animals.CategoryId == Catogoryid);
        }

        public Animal GetById(int id) => _repo.GetById(id);

        public IEnumerable<Animal> Get() => _repo.GetAll().ToList();

        public IEnumerable<Animal> GetMostRatedAnimales(int howMany, IEnumerable<Animal> animals)
        {
            if (animals == null)
                animals= _repo.GetAll();

            return _repo.OrderByDescending(animals).Take(howMany).ToList();
        }

		public bool AddAsync(Animal animal)
		{
            if (!animalValidation(animal))           
                return false;
            

            _repo.AddAsync(animal);
            return true;
        }

        public bool IsAlreadyIn(string name)
        {
			var animal = _repo.Find(a => a.Name!.ToLower() == name.ToLower()).FirstOrDefault();

            return animal != null;
		}

		public bool EditAsync(Animal animal)
		{
			if (!animalValidation(animal))
				return false;

			var oldanimal = _repo.Find(a => a.Id == animal.Id).FirstOrDefault();

            if (oldanimal == null) return false;
          
            oldanimal.Age = animal.Age;
            oldanimal.Name = animal.Name;
            oldanimal.PictureName = animal.PictureName;
            oldanimal.Description = animal.Description;
            oldanimal.CategoryId = animal.CategoryId;
            _repo.EditAsync(oldanimal);    
            return true;
		}

      
		public Animal Delete(int animalID)
		{
            var animal = _repo.GetById(animalID);
            if (animal == null)
                return null;
			_repo.Remove(animal);
            return animal;
		}

		public bool animalValidation(Animal animal)
		{
			if (animal == null)
				return false;


			string fileName = animal.PictureName!.ToLower();
			bool endsWithJpgOrPng = fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
			if (!endsWithJpgOrPng)
				return false;

			bool containsOnlyLetters = animal.Name!.All(c => Char.IsLetter(c));
			if (!containsOnlyLetters)
				return false;

			if (string.IsNullOrEmpty(animal.Name) ||
				animal.Age < 0 ||
                animal.Age > 30 ||
				string.IsNullOrEmpty(animal.PictureName) ||
				string.IsNullOrEmpty(animal.Description) ||
				animal.Description.Length < 3 ||
				animal.CategoryId < 1)
			{
				return false;
			}
			return true;
		}
	}
}
