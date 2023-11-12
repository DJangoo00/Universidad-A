# Universidad A

**Contexto**
Una universidad busca implementar una base de datos para gestionar la información de sus estudiantes, profesores, cursos y asignaturas. La base de datos se suministra con la información necesaria para facilitar el seguimiento de la asignación de profesores a cursos y asignaturas. La universidad proporciona los enunciados de las consultas específicas que se deben realizar en la base de datos, con el objetivo de obtener información relevante según sus necesidades, como la carga laboral de los profesores y otros aspectos cruciales para la gestión académica.


[![GitHub](https://badgen.net/badge/icon/github?icon=github&label)](https://github.com)
[![.NET](https://img.shields.io/badge/--512BD4?logo=.net&logoColor=ffffff)](https://dotnet.microsoft.com/)
[![NuGet](https://badgen.net/badge/icon/nuget?icon=nuget&label)](https://https://nuget.org/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/es-es/dotnet/csharp/)
[![GitHub](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)

**Table of Contents**📑

[TOCM]

[TOC]

## Requerimientos Funcionales 🌟

Listado de requerimientos

## Versiones Disponibles 📈
Versiones implementadas

1. V1.0
    Unica version desarrollada(default).

## Uso 🕹

Descripcion del uso:

**Versionado**
Para la implementacion de las versiones se puede realizar desde Header como en la imagen o desde Query con la key ver=1.0 (no es necesario indicar la version)
![](./Readme_Img/V1.1.png.png)


**Paginado**
Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:
![](./Readme_Img/paginado.png.png)


### Endpoints de Usuario ⚙️
**Método**: `POST`

#### 1. Registro de Usuario 🎉
Este endpoint permite a los usuarios registrarse en el sistema.

**Endpoint**: `http://localhost:5051/api/User/register`
**Version**: `1.0`
```JSON
{
    "nombre": "<nombre_de_usuario>",
    "password": "<password>",
    "correo": "<Email>"
}

```

#### 2. Generacion de Tokken ⏳
Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token.

**Endpoint**: `http://localhost:5051/api/User/token`
**Version**: `1.0`
```JSON
{
    "nombre": "<nombre_de_usuario>",
    "password": "<password>"
}
```

####  3. Refresh Token ♻️
Este endpoint permite actualizar el token el cual expira cada minuto.

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

**Endpoint**: `http://localhost:5051/api/User/refresh-token`
**Version**: `1.0`

#### 4. Asignacion de Rol 📜
Permite asignarle un rol diferente al usuario del predeterminado el cual es "empleado".

**Endpoint**: `http://localhost:5051/api/User/addrole`
**Version**: `1.0`

```JSON
{
    "nombre": "<nombre_de_usuario>",
    "password": "<password>",
    "role": "<role>"
}
```

**Otros Endpoints**

- Obtener Todos los Usuarios: GET. 🧲
**Endpoint**: `http://localhost:5051/api//User`

- Obtener Usuario por ID: GET. 🧲
**Endpoint**: `http://localhost:5051/api/User/{id}`

- Actualizar Usuario: PUT. ⛓
**Endpoint**: `http://localhost:5051/api/User/{id}`

- Eliminar Usuario: DELETE. 🗑
**Endpoint**: `http://localhost:5051/api/User/{id}`


### Endpoints Especificos ✅
Para el desarrollo de las consultas se analizaron las variables de estas para dar flexibilidad al desarrollo de estas.
**Método**: `GET`


#### 1. Listado de endpoints especificos.


**Consulta**: `1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.`
**Endpoint**: `http://localhost:5051/api/Person/1`


**Consulta**: `2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.`
**Endpoint**: `http://localhost:5051/api/Person/2`


**Consulta**: `3. Devuelve el listado de los alumnos que nacieron en "1999".`
**Endpoint**: `http://localhost:5051/api/Person/3`


**Consulta**: `4. Devuelve el listado de "profesores" que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en "K".`
**Endpoint**: `http://localhost:5051/api/Person/4`


**Consulta**: `5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador "7".`
**Endpoint**: `http://localhost:5051/api/Subject/5`


**Consulta**: `6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el "Grado en Ingeniería Informática (Plan 2015)".`
**Endpoint**: `http://localhost:5051/api/Person/6`


**Consulta**: `7. Devuelve un listado con todas las asignaturas ofertadas en el "Grado en Ingeniería Informática (Plan 2015)".`
**Endpoint**: `http://localhost:5051/api/Subject/7`


**Consulta**: `8. Devuelve un listado de los "profesores" junto con el nombre del "departamento" al que están vinculados. El listado debe devolver cuatro columnas, "primer apellido, segundo apellido, nombre y nombre del departamento." El resultado estará ordenado alfabéticamente de menor a mayor por los "apellidos y el nombre."`
**Endpoint**: `http://localhost:5051/api/Person/8`


**Consulta**: `9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif "26902806M".`
**Endpoint**: `http://localhost:5051/api/Subject/9`


**Consulta**: `10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el "Grado en Ingeniería Informática (Plan 2015)".`
**Endpoint**: `http://localhost:5051/api/Departament/10`


**Consulta**: `11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.`
**Endpoint**: `http://localhost:5051/api/Person/11`


**Consulta**: `12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.`
**Endpoint**: `http://localhost:5051/api/Person/12`


**Consulta**: `13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.`
**Endpoint**: `http://localhost:5051/api/Person/13`


**Consulta**: `14. Devuelve un listado con los profesores que no imparten ninguna asignatura.`
**Endpoint**: `http://localhost:5051/api/Person/14`


**Consulta**: `17. Devuelve el número total de **alumnas** que hay.`
**Endpoint**: `http://localhost:5051/api/Person/17`


**Consulta**: `18. Calcula cuántos alumnos nacieron en "1999".`
**Endpoint**: `http://localhost:5051/api/Person/18`


**Consulta**: `19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.`
**Endpoint**: `http://localhost:5051/api/Person/19`


**Consulta**: `24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.`
**Endpoint**: `http://localhost:5051/api/Person/24`


**Consulta**: `26. Devuelve todos los datos del alumno más joven.`
**Endpoint**: `http://localhost:5051/api/Person/26`


**Consulta**: `27. Devuelve un listado con los profesores que no están asociados a un departamento.`
**Endpoint**: `http://localhost:5051/api/Person/27`

**Consulta**: `29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.`
**Endpoint**: `http://localhost:5051/api/Person/29`



## Tecnologias 💻

-   NetCore 7.0
-   MySQL
-   GitHub

### Lenguajes Usados 💬

-   C#

### Dependencias Usadas 📦

-   "AspNetCoreRateLimit" Version="5.0.0"
-   "AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1"
-   "Microsoft.AspNetCore.Authentication.JwtBearer" Version="7.0.12"
-   "Microsoft.AspNetCore.Mvc.Versioning" Version="5.1.0"
-   "Microsoft.AspNetCore.OpenApi" Version="7.0.12"
-   "Microsoft.EntityFrameworkCore" Version="7.0.12"
-   "Microsoft.EntityFrameworkCore.Design" Version="7.0.12">
-   "Microsoft.Extensions.DependencyInjection" Version="7.0.0"
-   "Swashbuckle.AspNetCore" Version="6.5.0"
-   "System.IdentityModel.Tokens.Jwt" Version="7.0.3"
-   "Microsoft.IdentityModel.Tokens" Version="7.0.3"
-   "Serilog.AspNetCore" Version="7.0.0"
-   "FluentValidation.AspNetCore" Version="11.3.0"
-   "itext7.pdfhtml" Version="5.0.1"
-   "Pomelo.EntityFrameworkCore.MySql" Version="7.0.0"
-   "CsvHelper" Version="30.0.1"

## Estructura de la DataBase 🧱

> Estructura General.

![](.\Img\DbStructure.png)

## Informacion de la DataBase 🧱
Esta se encuentra en e; archivo DbInsert