using System;

namespace MustacheCat.Core.Injection {
	public interface IInjector {
		void Register<TType>(TType service);
		TType Inject<TType>();
		TType InjectOrCreate<TType>() where TType : new();
	}
}
