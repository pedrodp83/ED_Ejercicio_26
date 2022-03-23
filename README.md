# Ejercicio 26 Interfaces y clases abstractas
															***Primero DAW Semipresencial
															Entornos de desarrollo
															IES Pere Maria***

**GESTIÓN DE ESTUDIANTES-EMPLEADOS**

![UML ESTUDIANTES-EMPLEADOS](https://github.com/Cucala/ED_Ejercicio_26/blob/6ff7dd6c7d0e385c0aa51088355a543359931bf8/assets/uml.png)

Observa el esquema de clases de arriba. Trata de recoger una estructura formada por trabajadores de diversas categorías (obreros, trabajadores cualificados, becarios y jefes de departamento). Entiende este esquema como una propuesta para desarrollar la aplicación basada en objetos que se especifica a continuación. Tienes libertad para modificarlo de forma razonada en función de tu propia interpretación de la aplicación, y de las necesidades que se planteen en la especificación.

**ESPECIFICACIÓN:**

- Todas las clases tienen un constructor que admite todos sus campos como parámetros
- Crea una clase abstracta para empleados en la que informacion () será un método que devolverá un texto indicando:
	- para los becarios su carrera y departamento:
		> “Carrera: Biología, Departamento: Ciencias”
	- En el caso de cualificados titulación y departamento, por ejemplo:
		> “Titulación: Físico, Departamento: Ciencias”
	- Y en el caso de obreros su destino de trabajo y el Precio de las horas extra:
		> “Destino: Alicante, Precio Horas Extra: 80€”
- Crea una interface para Estudiantes. Dispondrá de la especificación de 3 métodos:
	- Exámenes: Devolverá una lista con 3 notas del estudiante, a partir de las cuales se calculará la nota media
	- Universidad: Proporcionará el nombre de la universidad a la que pertenece el alumno
	- NotaMedia: Calcula la media numérica (con un decimal) de las 3 notas que disponemos del alumno.
- La aplicación mostrará una lista (emplea, por ejemplo, el control listview) con el nombre y los apellidos de los empleados y cada vez que se seleccione un elemento de la lista se rellenarán textbox con toda la información almacenada del empleado.
- Existirá un botón añadir que permitirá crear un empleado del tipo que se desee, permitiendo rellenar todos los datos que permita dicho tipo.
- También se presentará un botón eliminar para borrar el usuario seleccionado.
- Ten en cuenta toda la funcionalidad implícita y la usabilidad que debe presentar la aplicación. Emplea todos los conocimientos que hemos ido adquiriendo para personalizar y mejorar tu aplicación, por ejemplo, ¿podrías utilizar algún menú contextual? ¿querrías añadir y controlar alguna restricción? ¿dar opciones al usuario, por ejemplo, para establecer una serie de universidades que sean las únicas que pueda elegir?
