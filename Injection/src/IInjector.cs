/**
 * An implementation of IInjector provides a service locator to access objects by strings.
 * Alternatively, objects may be accessed by type.
 */
namespace MustacheCat.Core.Injection {
	public interface IInjector {
		/**
		 * Register service of type TType with the injector.
		 * injector.inject<TType> will return this same object
		 */
		void Register<TType>(TType service);

		/**
		 * Register service with the inspector under name serviceName
		 * injector.inject(serviceName) will return this same object
		 */
		void Register(string serviceName, object service);

		/**
		 * Returns the object associated with type TType
		 */
		TType Inject<TType>();

		/**
		 * Returns the object associated with type serviceName, casting to TType
		 */
		TType Inject<TType>(string serviceName);
	}
}
