using System;
using System.Collections.Generic;

namespace MustacheCat.Core.Injection {
	public class Injector : IInjector {
		Dictionary<string, object> services;

		public Injector () {
			services = new Dictionary<string, Object>();
		}

		public void Register<TType> (TType service) {
			services[GetTypeKey(typeof(TType))] = service;
		}

    public void Register (string serviceName, object service) {
			services[serviceName] = service;
    }

		public TType Inject<TType> () {
			return (TType)services[GetTypeKey(typeof(TType))];
		}

    public TType Inject<TType> (string serviceName) {
			return (TType)services[serviceName];
    }

		private string GetTypeKey (Type type) {
			return type.FullName;
		}
	}
}
