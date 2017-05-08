# amcom Demo App

Este é um aplicativo criado para apresentar meu modelo de desenvolvimento e arquitetura, para aplicativos construídos com Xamarin Forms.

![alt text](https://github.com/jbravobr/Assets/blob/master/img01_amcom.jpeg?raw=true)

## Sobre o app

Através do acesso pelo usuário **user@amcom.com.br** e a senha **123**, o app apresenta uma tela com avarias já registradas de outros veículos. Ao clicar em uma avaria listada, iremos observar mais detalhes sobre o veículo, como foto e uma breve descrição, além das imagens recolhidas das avarias. Podemos clicar nas imagens, exibidas na galeria, e teremos a visualização full-screen (ao equema pop-up), neste se houve a detectação da geolocalização de onde a foto foi tirada, iremos observar isto na parte de baixo da tela ao lado esquerdo. 

Através do menu sandwich, podemos acessar a tela de novos registros, onde inserimos o nome do veículo, uma breve descrição e podemos capturar imagens, ao final da captura das imagens, podemos salvar o registro e automaticamente retornar para a listagem de avarias, tendo agora a última avaria listada na tela.

O app permanece logado, até que a opção sair seja utilizada no menu principal do app.

P.S = O nome utilizado no App, foi o selecionado pois utilizei uma biblioteca comprada para um projeto com o mesmo nome. Por configurações da licença, o nome do App precisa mantersse para que a biblioteca possa ser usada. A biblioteca em questão é a Grial UI KIT.

## Pré-requisitos

Para compillação é importante ter instalado os seguintes itens : **ANDROID SDK PLATFORM TOOLS 25.0.4** and the **Android SDK (API 23)** and / or **Android 7 (API 24)**. Preferencialmente API 23.  

## Instalação 

```
Clone este repositório e abra a solução utilizando Xamarin Studio ou Visual Studio >= 2015. Ambos em suas versões STABLE
```
## Algumas capturas

![alt text](https://github.com/jbravobr/Assets/blob/master/img02_amcom.jpeg?raw=true)
![alt text](https://github.com/jbravobr/Assets/blob/master/img03_amcom.jpeg?raw=true)

## Plugins utilzados (plug-ins via nuget ou Instalação direta)

| Plug-ins|
| ------------------- |
|Prism Library|
|FFImageLoading|
|sqlite-net-pcl|
|SQLite Extensions|
|PropertyChanged|
|Airbnb Lottie|
|Acr UserDialogs|
|Acr Settings|
|Grial UI KIT 2.0|

### Prism Library

Utilizei a biblioteca Prism para melhorar os recursos MVVM nativos da biblioteca Xamarin Forms e ter melhor controle e desempenho sobre a navegação dentro da App. Além de diminuir o acoplamento na App, permitindo uma maior testabilidade
[Mais informações](https://github.com/PrismLibrary/Prism)

### FFImageLoading

Utilizei o plug-in FFImageLoading para maior agilidade e flexibilidade ao trabalhar com imagens, permitindo tratar o borrão mais simples e a possibilidade de trabalhar com o cache
[Mais informações](https://github.com/luberda-molinet/FFImageLoading)

### sqlite-net-pcl

Utilizei o plug-in sqlite-net-pcl como o orquestrador do sistema de banco de dados para o aplicativo. Pensando em agregar mais valor à solução, introduzimos conceitos de dados offline, fazendo-nos usar esta solução para conseguir isso
[Mais informações](https://github.com/praeclarum/sqlite-net)

### SQLite Extensions

Utilizei o plug-in SQLite Extensions como uma forma de manter um relacionamento saudável entre entidades possíveis no nosso aplicativo. Assim, sem alterações de esquema no banco de dados, podemos persistir e recuperar a forma completa de informação e relacionados
[Mais informações](https://bitbucket.org/twincoders/sqlite-net-extensions)

### PropertyChanged (Fody)

Utilizei o plug-in PropertyChanged para tornar mais fácil usar propriedades "auto-observáveis" através da interface INotifyPropertyChanged e assim manter o padrão MVVM mais fluido
[Mais informações](https://github.com/Fody/PropertyChanged)

### Airbnb Lottie

Utilizamos o plug-in Airbnb Lottie (porquê não deixar mais bonito?) para trazer e exemplificar como podemos trabalhar com animações de uma forma prática e performativa usando Xamarin Forms
[Mais informações](https://github.com/martijn00/LottieXamarin)

### Acr UserDialogs

Utilizei o plug-in Acr UserDialogs para trabalhar com a exibição de alertas e mensagens personalizadas de forma simples através do projeto PCL
[Mais informações](https://github.com/aritchie/userdialogs)

### Acr Settings

Utilizei o plug-in Acr Settings para que possamos acessar recursos de armazenamento baseados em valores-chave, padrões de plataforma
[Mais informações](https://github.com/aritchie/userdialogs)

### Grial UI KIT 2.0

Utilizei esta biblioteca, pois a mesma contém uma série de controles, estilos e padrões de telas pré-fabricados, agilizando o processo de desenvolvimento de telas
[Mais informações](http://grialkit.com)

## Construído com

* [Xamarin Forms](https://www.nuget.org/packages/Xamarin.Forms/) - Xamarin Forms (Last Stable Version)
* [Mono](http://www.mono-project.com/docs/about-mono/releases/4.8.0/) - Mono (Last Stable Version)

## Autor

* **Rodrigo Amaro**

## Licença

Este projeto é licenciado sob a Licença MIT