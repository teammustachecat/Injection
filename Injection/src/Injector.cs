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

    public TType Remove<TType>() {
			return Remove<TType>(GetTypeKey(typeof(TType)));
    }

    public TType Remove<TType>(string serviceName) {
			TType service = Inject<TType>(serviceName);
			services.Remove(serviceName);
			return service;
    }

		public TType Inject<TType> () {
			return (TType)services[GetTypeKey(typeof(TType))];
		}

    public TType Inject<TType> (string serviceName) {
			if (!services.ContainsKey(serviceName)) {
				throw new KeyNotFoundException("Service of (type, name) not found: "
					 + "(" + typeof(TType).FullName + ", " + serviceName + ")");
			}
			return (TType)services[serviceName];
    }

		private string GetTypeKey (Type type) {
			return type.FullName;
		}
  }
}
