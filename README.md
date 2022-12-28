# SystemRCP

## Technologie:
* Visual Studio 2022
* .NET 6

## Opis
SystemRCP jest to aplikacja konsolowa, która pozwala odczytać czas pracy pracowników, na podstawie informacji załączonych w plikach csv. Pliki rcp1.csv i rcp2.csv, umieszczone są w folderze 'bin/Debug/net6.0/'.
Program sam wyszukuje pliki w folderze i następnie wczytuje ich zawrtość. Program wyświetla takie infomracje jak: 

1. Kod pracownika
2. Date
3. Godziny pracy
4. Łączny czas pracy

Każdy pracownik posiada tylko jeden obiekt na dany dzień.
