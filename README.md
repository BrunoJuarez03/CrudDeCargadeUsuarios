# Crud Simple de carga de usuarios.

![Static Badge](https://img.shields.io/badge/Winforms.Net--purple?logo=C%23)

<p>Este proyecto se realizo para practicar mis habilidades en C# y MySql, y cumple la funcion facilitar la carga de multiples usuarios a una base de datos, fue diseñado con la idea de que se utilizaria la tabla de usuarios para permitir el acceso a estos a la pagina de ventas de una distribuidora mayorista.</p>

## Instalacion

* Descargar el archivo "Application Files.zip".
* Descromprimer los archivos y ejecutar "setup.exe"
* Hacer click en instalar.
* El programa se ejecutara en cuanto se termine la instalacion. 

(nota, se necesita tener instalada alguna instancia de mysql en el dispositivo para el correcto funcionamiento de la aplicacion)

## Uso

una vez habierto el programa este se nos presentara con un formulario de conexion a una base de datos.


<p align="center">
  <img src="https://github.com/BrunoJuarez03/CrudDeCargadeUsuarios/assets/137836933/3b8bbf7e-a761-4e5d-bfa5-f5373592ed32" />
</p>

Rellenamos el formulario y procedemos a conectar, o precionamos crear base de datos en caso de no tener una. Esto nos llevara a la ventana principal de la aplicacion donde disponemos de las funciones necesarias para gestionar la tabla de usuarios, es decir, todas las funciones comunes que presenta un CRUD (Create, Read, Update y Delete). En caso de no tener creada la tabla usuarios clickeamos el boton en la esquina inferior izquierda. 


<p align="center">
  <img src="https://github.com/BrunoJuarez03/CrudDeCargadeUsuarios/assets/137836933/4c8eca92-bfeb-4b2c-ab9e-6569250466fc" />
</p>

Las funciones de la aplicacion son bastante intuitivas, al clickear en una de estas como "Añadir Usuario" se nos habilitara el formulario y podremos rellenarlo a gusto, una vez escrita la informacion necesaria le daremos click en guardar y los datos seran cargados a la base de datos.

![image](https://github.com/BrunoJuarez03/CrudDeCargadeUsuarios/assets/137836933/a2158052-d260-4bb7-895c-513cafa05bc0)

Para editar los datos de un usuario seleccionaremos con un click en la tabla al usuario deseado y presionaremos el boton "Editar usuario", los datos se cargaran al formulario y podremos editarlos sin problema, una vez hecho le damos a guardar y los datos seran actualizados. De la misma manera, si deseamos eliminar un registro de la tabla tendremos que seleccionarlo con un click y presionar el boton "Eliminar usuario", se nos presentara una ventana si estamos seguros y sera eliminado el registro.


