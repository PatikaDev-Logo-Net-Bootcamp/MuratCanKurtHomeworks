## Homework four İstenenler:

* İlerlediğimiz projede yazdığımız CompanyService için sadece add ve get işlemi yapmıştık. Delete ve Update methodlarını implement edip apii de bunları kullanmalarını bekliyorum. Proje linkte ulaşabilirsiniz.
* https://drive.google.com/file/d/1Pc-3Fa_MjG3SLuO7YhwxJfFTbKO_IMrY/view?usp=drivesdk ,

* Ödeve artı 1 puan bonus

* Jwt token örneğindeki user ve password bilgilerini db çekecek şekilde UserService yazılması

## Homework four requests:
* We have coded only add and get operations for CompanyService in our lecture project, It is expected to add Delete and Update methods and use these in the api. We can use the lecture project to build on.
	- [Download Lecture Project]{https://drive.google.com/file/d/1Pc-3Fa_MjG3SLuO7YhwxJfFTbKO_IMrY/view?usp=drivesdk}
### Bonus Request for 1 point
* Code the UserService to fecth user and password informations of Jwt example from db

# Homework notes

## Things I did before starting to do the Homework4 requests

### The whole project created from scratch with minor changes and refactorings
	- Necessary components of First.APP project included into ny main project ""Homework4" which is replacement of First.Api
	- Remaining of the First.APP is not created in my project.
	- Console project is not created.
	- All the packages have the version 5.0.15
	- WeatherForecast and its controller removed
	- Models:
		- CompanyResponse -> ResponseModel
		- TesterModel -> UserRegisterModel
		- UserModel -> UserLoginModel
	- Filters:
		- ValidationFilterAttribute in the First.APP is added to my project
	- Attributes/MaxFileSizeAttribute which was in the First.APP is add to my project
	- Other than these there are some minor naming changes.

## My Homework four
- Get all companies before trying update and delete.
