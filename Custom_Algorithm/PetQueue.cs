using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    public class Pet
    {
        private string type;

        public Pet(string type)
        {
            this.type = type;
        }

        public string GetPetType()
        {
            return type;
        }
    }

    public class Dog : Pet
    {
        public Dog() : base("Dog")
        {
        }
    }

    public class Cat : Pet
    {
        public Cat() : base("Cat") { }
    }

    public class PetEnterQueue
    {
        private Pet pet;
        private int count;

        public PetEnterQueue(Pet pet, int count)
        {
            this.pet = pet;
            this.count = count;
        }

        public Pet Pet { get => pet; }
        public int Count { get => count; }

        
    }

    public class PetQueue
    {
        private Queue<PetEnterQueue> dogQueue;
        private Queue<PetEnterQueue> catQueue;
        private int accumulator;

        public PetQueue()
        {
            dogQueue = new Queue<PetEnterQueue>();
            catQueue = new Queue<PetEnterQueue>();
            accumulator = 0;
        }

        public void Add(Pet pet)
        {
            PetEnterQueue petEnterQueue = new PetEnterQueue(pet, accumulator++);

            if (petEnterQueue.Pet.GetPetType() == "Dog")
            {
                dogQueue.Enqueue(petEnterQueue);
            }
            else
            {
                catQueue.Enqueue(petEnterQueue);
            }
        }

        public Dog PollDog()
        {
            if (dogQueue.Count == 0)
            {
                Console.WriteLine("The queue has no dogs.");
                return null;
            }

            return (Dog)dogQueue.Dequeue().Pet;
        }

        public Cat PollCat()
        {
            if (catQueue.Count == 0)
            {
                Console.WriteLine("The queue has no cats.");
                return null;
            }

            return (Cat)catQueue.Dequeue().Pet;
        }

        public Pet PollAll()
        {
            if (dogQueue.Count != 0 && catQueue.Count != 0)
            {
                int catPrior = catQueue.Peek().Count;
                int dogPrior = dogQueue.Peek().Count;
                return (catPrior > dogPrior) ? catQueue.Dequeue().Pet : dogQueue.Dequeue().Pet;
            }
            else if (dogQueue.Count != 0)
            {
                return dogQueue.Dequeue().Pet;
            }
            else if (catQueue.Count != 0)
            {
                return catQueue.Dequeue().Pet;
            }
            else
            {
                Console.WriteLine("There is no pet in queue");
                return null;
            }
        }

        public bool IsEmpty()
        {
            return (dogQueue.Count == 0 && catQueue.Count == 0);
        }

        public bool IsDogEmpty()
        {
            return dogQueue.Count == 0;
        }

        public bool IsCatEmpty()
        {
            return catQueue.Count == 0;
        }
    }
}
