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
		 * Remove the service of the given type from the injector.
		 * Returns the object being removed
		 */
		TType Remove<TType>();

		/**
		 * Remove the service with the given name from the injector.
		 * Returns the object being removed
		 */
		TType Remove<TType>(string serviceName);

		/**
		 * Returns the object associated with type TType
		 * Attempting to Inject a non-registered TType will throw a KeyNotFoundException
		 */
		TType Inject<TType>();

		/**
		 * Returns the object associated with type serviceName, casting to TType
		 * Attempting to Inject a non-registered serviceName will throw a KeyNotFoundException
		 */
		TType Inject<TType>(string serviceName);
	}
}
