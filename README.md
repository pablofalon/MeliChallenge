# Meli Challenge
Meli Challenge es una solucion propuesta a la problematica planteada por el desafio de MELI.


## Requerimientos funcionales
<strong>1) Se solicita una aplicacion que identifique una posicion a partir de 3 posiciones conocidas. Se considera X,Y como unidad de medida.</strong>

<p>Para satisfacer este punto se usara el algoritmo de Trilateracion. El mismo realiza su calculo a partir de 3 puntos (x1,y1),(x2,y2),(x3,y3) y sus respectivas distancias (r1,r2,r3) al punto incognita (x0,y0). Al ingresar el valor de dichos puntos, se calculara la posicion del punto incognita.<a href="https://es.wikipedia.org/wiki/Trilateraci%C3%B3n"> https://es.wikipedia.org/wiki/Trilateraci%C3%B3n </a>

<strong>2) Se solicita que a partir de la informacion enviada (Mensaje) por los 3 satelites, se determine el mensaje completo generado por el elemento en la posicion desconocida.</strong>
<p>Para satisfacer este punto se creara la logica necesaria para establecer un mensaje completo a partir de los 3 mensajes enviados por los satelites.</p>

<strong>3) Debe existir un punto de entrada que ingresando las posiciones de los 3 satelites con sus respectivos mensajes, determine el mensaje completo y la posicion de la nave.</strong>
<p>Se creara un endpoint que tome como entrada la informacion de los 3 satelites</p>
<p>Informacion por satelite => Nombre del Satelite, Distancia a la nave emisora, Mensaje</p>
<p>y devuelva como resultado</p>
<p>Informacion de la nave => Posicion (X,Y) y mensaje decodificado</p>

<strong> 4)Debe existir un punto de entrada que ingresando la distancia de un unico satelite y el mensaje recibido, pueda determinar la posicion de la nave y el mensaje completo enviado.</strong>
<p>Se implementara un endpoint que reciba como mensaje el nombre del satelite, distancia al emisor y mensaje. Se determinara el mensaje a partir de la informacion guardada</p>
<p>en memoria y de consultas realizadas previamente.</p>


# Tecnologias Involucradas
- Visual Studio 2019 16.8 o posterior
- Lenguaje C# 
-.NET 5.0 SDK o posterior
- Microsoft Azure API management

# Arquitectura de la solucion
La solucion se encuentra planteadas en 3 proyectos:
<ul>
<li>MeliChallenge.API</li>
<li>MeliChallenge.Services</li>
<li>MeliChallenge.Domain</li>
<li>MeliChallenge.Test</li>
</ul>

## Detalles

- <strong>MeliChallenge.API:</strong> Es el proyecto de API .NetCore. Posee una estructura de proyecto basada en plantilla de WEBAPI. Se considera esta como la capa superior
de la solucion y es la que brinda la informacion necesaria para cumplir con el requisito de negocio.

- <strong>MeliChallenge.Services:</strong> Es un proyecto de libreria de clases. El mismo contiene las clases con la logica de negocio implementada para resolver la posicion y el mensaje
de la nave. Tambien contiene las interfaces de los servicios implementados. Para evitar complejidad se sumo la logica de repositorios en este proyecto.

- <strong> MeliChallenge.Domain:</strong> Es un proyecto de libreria de clases. Contiene las clases de dominio del problema.

- <strong> MeliChallenge.Test:</strong> Es un proyecto de libreria de clases. Contiene los test unitarios y de integracion de la app. Solo se encuentra implementado a modo
ilustrativo un metodo de prueba de un endpoint de la WEBAPI con el fin de mostrar la idea de test unitario y su forma de platearse (Patron AAA -Arrange/Act/Assert)

- Adicionalmente se agrega a la solucion una carpeta donde se encuentra la coleccion Postman para realizar las llamadas a los endpoints y configurar los ambientes de pruebas.
<p>Para realizar las pruebas recordar de importar tanto coleccion como ambiente. En el caso de no utilizar los ambientes con postman realizar los reemplazos:<p>

<p><strong>{{baseUrl}}</strong> por <strong>http://melichallengeapp.azurewebsites.net/</strong> o <strong>http://localhost:18298</strong> segun se requiera<p>
<p><strong>{{satelliteName}}</strong> por <strong>Sato</strong> o <strong>Kenobi</strong> o <strong>Skywalker</strong><p>


## Consideraciones Importantes:
- No se consiguio la solucion con los puntos (X,Y) planteados para cada satelite en el desafio.
De todas maneras, se pudo resolver el desafio aplicando otros valores pero que son aceptados por el calculo de trilateracion.

<p>Satellite "Kenobi" PositionX=4,PositionY=5 </p>
<p>Satellite "Skywalker", PositionX=4,PositionY=7</p>
<p>Satellite "Sato", PositionX=5,PositionY=7 </p>

 
- De vital importancia que se ejecute primero el endpoint que contiene toda la informacion (/topsecret) para completar informacion del repositorio.
Si se ejecuta topsecret/{{satelliteName}} primero, el sistema informara que no existen datos suficientes.

- Se considera que un mensaje tiene TAMAÑO FIJO de 5 y puede incluir vacios. Ej: {"Este","","","","Secreto"}


## Ejecucion
Para ejecutar esta solucion debera
<ol>
<li>Desde su cmd ejecutar git clone https://github.com/pablofalon/MeliChallenge.git</li>
<li>Una vez clonada la solucion, abrir Visual studio y abrir la solucion</li>
<li>Ejecutar la compilacion</li>
</ol>
Por defecto esta configurada para ejecutarse en el puerto 18298. Entonces para ver la ejecucion debera abrir su navegador e ir a <a>http://localhost:18298</a>

### Despliegue
La API se encuentra desplegada en la cloud plattform de Microsoft Azure. La misma esta bajo membresia gratuita con fines educativos o de desarrollos pequeños y personales.


### URL
https://melichallengeapp.azurewebsites.net/

El servicio cuenta con SWAGGER, lo cual permite visualizar documentacion de la api.

## Muchas Gracias!
