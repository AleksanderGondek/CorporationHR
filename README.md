Zeby https dzialalo:

1. Idz do : C:\Users\{YourUserName}\Documents\IISExpress\config
2. Otworz: applicationhost.config
3. Znajdz wpis odpowiadajacy za CorpoHR
			Na przyklad
			```
            <site name="CorporationHR(1)" id="7">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="C:\Users\Aleksander\SkyDrive\Visual Studio 2013 Projects\CorporationHR\CorporationHR" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation="*:57420:localhost" />
                    <binding protocol="https" bindingInformation="*:44300:localhost" />
                </bindings>
            </site>
			```
4. Dodaj wpis odpowiadajacy za obsluge https : 
	```
	<binding protocol="https" bindingInformation="*:44300:localhost" />
	```
	Koniecznie ustaw taki port, bo jest ladne przekierowanie wpisane do niego, w appce by sie domyslnie otwieralo w ssl
	
5. Powinno ladziac :)