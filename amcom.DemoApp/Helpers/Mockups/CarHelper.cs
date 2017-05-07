using System.Collections.Generic;
using System;

namespace amcom.DemoApp
{
	public static class CarHelper
	{
		static readonly List<Car> cars = new List<Car>();

		public static List<Car> BulkCarList()
		{
			return ConfigureCars();
		}

		public static List<Photo> BulkPhotoList(int carId)
		{
			var list = new List<Photo>
			{
				new Photo {CarId= carId, Name = "quebrado1.png", PhotoStream = "quebrado1.png",PickDate = DateTimeOffset.Now},
				new Photo {CarId= carId, Name = "quebrado2.png", PhotoStream = "quebrado2.png",PickDate = DateTimeOffset.Now},
				new Photo {CarId= carId, Name = "quebrado3.png", PhotoStream = "quebrado3.png",PickDate = DateTimeOffset.Now},
				new Photo {CarId= carId, Name = "quebrado4.png", PhotoStream = "quebrado4.png",PickDate = DateTimeOffset.Now},
				new Photo {CarId= carId, Name = "quebrado5.png", PhotoStream = "quebrado5.png",PickDate = DateTimeOffset.Now},
				new Photo {CarId= carId, Name = "quebrado6.png", PhotoStream = "quebrado6.png",PickDate = DateTimeOffset.Now}
			};

			return list;
		}

		static List<Car> ConfigureCars()
		{
			var c1 = new Car
			{
				Id = 1,
				Name = "Porsche Carrera GT",
				Description = "Um total de 1.270 Carrera GT foram produzidos e este bólido atinge, sem nenhum problema, uma velocidade máxima de 329 km/h.",
				Image = "car1.png",
				Photos = BulkPhotoList(1)
			};
			cars.Add(c1);

			var c2 = new Car
			{
				Id = 2,
				Name = "Mercedes-Benz SLR McLaren",
				Description = "Um carro construído em conjunto com o fabricante de carros de Fórmula 1 da McLaren em Woking, Surrey, na Grã-Bretanha.",
				Image = "car2.png",
				Photos = BulkPhotoList(2)
			};
			cars.Add(c2);

			var c3 = new Car
			{
				Id = 3,
				Name = "Lamborghini Murcielago LP640",
				Description = "O velocímetro do LP640 marca nada menos que 339 km/h.",
				Image = "car3.png",
				Photos = BulkPhotoList(3)
			};
			cars.Add(c3);

			var c4 = new Car
			{
				Id = 4,
				Name = "Bristol Fighter S",
				Description = "A mecânica é cortesia da Dodge, um enorme V10 de 8.0 litros que permite ao Figther desenvolver 337 km/h.",
				Image = "car4.png",
				Photos = BulkPhotoList(4)
			};
			cars.Add(c4);

			var c5 = new Car
			{
				Id = 5,
				Name = "Ford GT",
				Description = "Esse carro está equipado com um motor V8 de 5.4 litros, auxiliado por um compressor duplo, o que lhe permite superar a barreira dos 341 km/h.",
				Image = "car5.png",
				Photos = BulkPhotoList(5)
			};
			cars.Add(c5);

			var c6 = new Car
			{
				Id = 6,
				Name = "Lamborghini Murcielago SV",
				Description = "Estes são equipados com um V12 de 6.5 litros capaz de gerar 670 cv, o que catapulta o Murciélago SV aos 342 km/h.",
				Image = "car6.png",
				Photos = BulkPhotoList(6)
			};
			cars.Add(c6);

			var c7 = new Car
			{
				Id = 7,
				Name = "Pagani Zonda F",
				Description = "O Zonda F traz um V12 de 7.3 litros, que lhe permite atingir os 346 km/h. Foram construídas apenas quarenta unidades do modelo.",
				Image = "car7.png",
				Photos = BulkPhotoList(7)
			};
			cars.Add(c7);

			var c8 = new Car
			{
				Id = 8,
				Name = "Jaguar XJ220",
				Description = "A ideia principal da fabricante era desenvolver um modelo que atingisse as 220 mph, daí o porquê do nome, mas a velocidade mais alta registrada é de 217 mph, cerca de 349 km/h.",
				Image = "car8.png",
				Photos = BulkPhotoList(8)
			};
			cars.Add(c8);

			var c9 = new Car
			{
				Id = 9,
				Name = "Enzo Ferrari",
				Description = "É praticamente um Fórmula 1 com dois lugares. Carrega um V12 de 6.0 litros capaz de levá-la aos 350 km/h no velocímetro.",
				Image = "car9.png",
				Photos = BulkPhotoList(9)
			};
			cars.Add(c9);


			var c10 = new Car
			{
				Id = 10,
				Name = "Ascari A10",
				Description = "O A10 é movido por um bloco 5.0 litros V8 de origem BMW de mais de 525 cavalos de potência.",
				Image = "car10.png",
				Photos = BulkPhotoList(10)
			};
			cars.Add(c10);

			return cars;
		}
	}
}