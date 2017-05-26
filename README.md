# MessageProcessor

Se crearon dos soluciones web para las cuales se maneja la misma arquitecura basada en capas (ServicioRest, Logica de negocio, modelos y acceso a datos). Las soluciones son:
- WordProcessor: Procesa los mensajes del cliente y los almacena en persistencia, consta de cuatro proyectos:
	* WordProcessor : Capa de servicio Rest
	* WordProcessor.Business : Capa de logica de negocio encargada de obtener las estadisticas
	* WordProcessor.Interfaces : Capa de contratos (futuro inversiòn del control)
	* WordProcessor.Models : Modelos que representan los DBobjects con Entity Framework.
- WordGenerator: Genera mensajes de texto y los envìa al "1- WordProcessor", consta de tres proyectos:
	* WordGenerator : Capa de servicio Rest
	* WordGenerator.Business : Capa de lògica para generar mensajes
	* WordGenerator.Model : Modelo de mensaje y sus atributos

Còmo probar:
- Ejecutar el script CreateDB.sql en SQLServerExpress para crear la base de datos
- En IIS agregar dos nuevos sitios web, uno en el puerto 1024 y otro en el 2048
- Abrir la soluciòn deseada para depuraciòn si es el caso.
- El servicio de generaciòn de mensajes expone un mètodo:
	* **GET** http://localhost:2048/WordGenerator/api/Generator/10 => numero de mensajes a generar
- El servicio que procesa los mensajes expone dos mètodos:
	* **POST** http://localhost:1024/WordProcessor/api/message recibe los mensajes a procesar
	* **GET** http://localhost:1024/WordProcessor/api/message muestra los mensajes procesados
- Verificar que la llave "WordProcessorUrl" en el web.config de WordGenerator apunte a la URI del WordProcessor, por defecto apunta a http://localhost:1024/WordProcessor/
