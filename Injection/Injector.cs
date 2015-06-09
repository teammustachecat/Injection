using System;
using System.Collections.Generic;

namespace MustacheCat.Core.Injection {
	public class Injector : IInjector {
		Dictionary<Type, Object> services;

		public Injector () {
			services = new Dictionary<Type, Object>();
		}

		public void Register<TType>(TType service) {
			services[typeof(TType)] = service;
		}

		public TType Inject<TType>() {
			return (TType)services[typeof(TType)];
		}

		public TType InjectOrCreate<TType>() where TType : new() {
			if (!services.ContainsKey(typeof(TType))) {
				var service = new TType();
				Register<TType>(service);
			}
			return Inject<TType>();
		}
	}
}
