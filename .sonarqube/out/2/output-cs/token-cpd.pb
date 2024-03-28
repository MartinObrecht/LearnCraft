à
@/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Program.cs
public 
class 
Program 
{ 
private		 
static		 
void		 
Main		 
(		 
string		 #
[		# $
]		$ %
args		& *
)		* +
{

 
var 
builder 
= 
WebApplication $
.$ %
CreateBuilder% 2
(2 3
args3 7
)7 8
;8 9
builder 
. 
Services 
. ,
 AddApplicationInsightsExtensions 9
(9 :
builder: A
.A B
ConfigurationB O
)O P
;P Q
builder 
. 
Logging 
.  
AddLoggingExtensions ,
(, -
builder- 4
.4 5
Configuration5 B
)B C
;C D
builder 
. 
Services 
. 
AddControllers '
(' (
)( )
. 
AddJsonOptions 
( 
options #
=>$ &
{ 
options 
. !
JsonSerializerOptions -
.- .

Converters. 8
.8 9
Add9 <
(< =
item= A
:A B
newC F#
JsonStringEnumConverterG ^
(^ _
)_ `
)` a
;a b
} 
) 
; 
builder 
. 
Services 
. 

AddSwagger #
(# $
)$ %
;% &
builder 
. 
Services 
. #
AddEndpointsApiExplorer 0
(0 1
)1 2
;2 3
builder 
. 
Services 
. 
AddDbContext %
<% &
CachorroContext& 5
>5 6
(6 7
options7 >
=>? A
{ 	
options 
. 
UseInMemoryDatabase '
(' (
$str( 3
)3 4
;4 5
} 	
)	 

;
 
var 
app 
= 
builder 
. 
Build 
(  
)  !
;! "
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
app!! 
.!! 
UseHttpsRedirection!! 
(!!  
)!!  !
;!!! "
app## 
.## 
UseAuthorization## 
(## 
)## 
;## 
app%% 
.%% 
MapControllers%% 
(%% 
)%% 
;%% 
app'' 
.'' 
Run'' 
('' 
)'' 
;'' 
}(( 
})) å
_/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Extensions/Telemetry/LoggingExtensions.cs
	namespace 	

LearnCraft
 
. 
Api 
. 

Extensions #
.# $
	Telemetry$ -
{ 
public 

static 
class 
LoggingExtensions )
{ 
public 
static 
void  
AddLoggingExtensions /
(/ 0
this0 4
ILoggingBuilder5 D
loggingBuilderE S
,S T
IConfiguration 
configuration $
)$ %
{ 	
loggingBuilder 
. 
ClearProviders )
() *
)* +
;+ ,
loggingBuilder		 
.		 

AddConsole		 %
(		% &
)		& '
;		' (
loggingBuilder 
. "
AddApplicationInsights 1
(1 2+
configureTelemetryConfiguration /
:/ 0
(1 2
config2 8
)8 9
=>: <
config 
. 
ConnectionString +
=, -
configuration. ;
[; <
$str< c
]c d
,d e5
)configureApplicationInsightsLoggerOptions 9
:9 :
(; <
options< C
)C D
=>E G
{H I
}J K
) 
; 
} 	
} 
} ³
k/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Extensions/Telemetry/ApplicationInsightsExtensions.cs
	namespace 	

LearnCraft
 
. 
Api 
. 

Extensions #
.# $
	Telemetry$ -
;- .
public 
static 
class )
ApplicationInsightsExtensions 1
{ 
public 

static 
void ,
 AddApplicationInsightsExtensions 7
(7 8
this8 <
IServiceCollection= O
servicesP X
,X Y
IConfigurationZ h
configurationi v
)v w
{ 
services 
. +
AddApplicationInsightsTelemetry 0
(0 1
options1 8
=>9 ;
{ 
options		 
.		 
ConnectionString		 (
=		) *
configuration		+ 8
[		8 9
$str		9 `
]		` a
;		a b
}

 
)

 
;

 
} 
} õ
]/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Extensions/Swagger/SwaggerExtensions.cs
	namespace 	

LearnCraft
 
. 
Api 
. 

Extensions #
.# $
Swagger$ +
;+ ,
public 
static 
class 
SwaggerExtensions %
{ 
public 

static 
void 

AddSwagger !
(! "
this" &
IServiceCollection' 9
services: B
)B C
{ 
services		 
.		 
AddApiVersioning		 !
(		! "
opt		" %
=>		& (
{

 	
opt 
. 
ReportApiVersions !
=" #
true$ (
;( )
opt 
. /
#AssumeDefaultVersionWhenUnspecified 3
=4 5
true6 :
;: ;
opt 
. 
DefaultApiVersion !
=" #
new$ '

ApiVersion( 2
(2 3
$num3 4
,4 5
$num6 7
)7 8
;8 9
} 	
)	 

;
 
services 
. #
AddVersionedApiExplorer (
(( )
opt) ,
=>- /
{ 	
opt 
. 
GroupNameFormat 
=  !
$str" *
;* +
opt 
. %
SubstituteApiVersionInUrl )
=* +
true, 0
;0 1
} 	
)	 

;
 
services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
services 
. 
AddSwaggerGen 
( 
)  
;  !
services 
. 
ConfigureOptions !
<! "#
ConfigureSwaggerOptions" 9
>9 :
(: ;
); <
;< =
} 
}  
c/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Extensions/Swagger/ConfigureSwaggerOptions.cs
	namespace 	

LearnCraft
 
. 
Api 
. 

Extensions #
.# $
Swagger$ +
;+ ,
public 
class #
ConfigureSwaggerOptions $
:% &
IConfigureOptions' 8
<8 9
SwaggerGenOptions9 J
>J K
{		 
private

 
readonly

 *
IApiVersionDescriptionProvider

 3
	_provider

4 =
;

= >
public 
#
ConfigureSwaggerOptions "
(" #*
IApiVersionDescriptionProvider# A
providerB J
)J K
=>L N
	_provider 
= 
provider 
; 
public 

void 
	Configure 
( 
SwaggerGenOptions +
options, 3
)3 4
{ 
foreach 
( 
var 
description  
in! #
	_provider$ -
.- ."
ApiVersionDescriptions. D
)D E
{ 	
options 
. 

SwaggerDoc 
( 
description 
. 
	GroupName %
,% &#
CreateInfoForApiVersion '
(' (
description( 3
)3 4
)4 5
;5 6
} 	
} 
private 
static 
OpenApiInfo #
CreateInfoForApiVersion 6
(6 7!
ApiVersionDescription7 L
descriptionM X
)X Y
{ 
var 
info 
= 
new 
OpenApiInfo "
{ 	
Title 
= 
$str $
,$ %
Version 
= 
description !
.! "

ApiVersion" ,
., -
ToString- 5
(5 6
)6 7
,7 8
Description 
= 
$str V
,V W
Contact   
=   
new   
(   
)   
{!! 
Name"" 
="" 
$str"" '
,""' (
Email## 
=## 
$str## 5
}$$ 
}%% 	
;%%	 

if'' 

('' 
description'' 
.'' 
IsDeprecated'' $
)''$ %
{(( 	
info)) 
.)) 
Description)) 
+=)) 
$str))  H
;))H I
}** 	
return,, 
info,, 
;,, 
}-- 
}.. ŽI
X/home/martin/Workspace/learn-craft/src/LearnCraft.Api/Controllers/CachorrosController.cs
	namespace 	

LearnCraft
 
. 
Api 
. 
Controllers $
;$ %
[ 
ApiController 
] 
[		 

ApiVersion		 
(		 
$str		 
)		 
]		 
[

 
Route

 
(

 
$str

 /
)

/ 0
]

0 1
public 
class 
CachorrosController  
:! "
ControllerBase# 1
{ 
private 
readonly 
CachorroContext $
_cachorroContext% 5
;5 6
public 

CachorrosController 
( 
CachorroContext .
cachorroContext/ >
)> ?
{ 
_cachorroContext 
= 
cachorroContext *
;* +
} 
[ 
HttpGet 
] 
[ 
Produces 
( 
contentType 
: 
$str -
)- .
]. /
[  
ProducesResponseType 
( 
typeof  
(  !
IEnumerable! ,
<, -
Cachorro- 5
>5 6
)6 7
,7 8
StatusCodes9 D
.D E
Status200OKE P
)P Q
]Q R
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status204NoContent& 8
)8 9
]9 :
[  
ProducesResponseType 
( 
StatusCodes %
.% &(
Status500InternalServerError& B
)B C
]C D
public 

async 
Task 
< 
IActionResult #
># $
GetAsync% -
(- .
). /
{ 
var 
	cachorros 
= 
await 
_cachorroContext .
.. /
	Cachorros/ 8
.8 9
ToListAsync9 D
(D E
)E F
;F G
if 

( 
	cachorros 
. 
Count 
== 
$num  
)  !
{ 	
return   
	NoContent   
(   
)   
;   
}!! 	
return"" 
Ok"" 
("" 
	cachorros"" 
)"" 
;"" 
}## 
[%% 
HttpGet%% 
(%% 
$str%% 
)%% 
]%% 
[&& 
Produces&& 
(&& 
contentType&& 
:&& 
$str&& -
)&&- .
]&&. /
[''  
ProducesResponseType'' 
('' 
typeof''  
(''  !
Cachorro''! )
)'') *
,''* +
StatusCodes'', 7
.''7 8
Status200OK''8 C
)''C D
]''D E
[((  
ProducesResponseType(( 
((( 
StatusCodes(( %
.((% &
Status204NoContent((& 8
)((8 9
]((9 :
[))  
ProducesResponseType)) 
()) 
StatusCodes)) %
.))% &(
Status500InternalServerError))& B
)))B C
]))C D
public** 

async** 
Task** 
<** 
IActionResult** #
>**# $
GetByIdAsync**% 1
(**1 2
int**2 5
id**6 8
)**8 9
{++ 
var,, 
cachorro,, 
=,, 
await,, 
_cachorroContext,, -
.,,- .
	Cachorros,,. 7
.,,7 8
	FindAsync,,8 A
(,,A B
id,,B D
),,D E
;,,E F
if.. 

(.. 
cachorro.. 
==.. 
null.. 
).. 
{// 	
return00 
NotFound00 
(00 
)00 
;00 
}11 	
return22 
Ok22 
(22 
cachorro22 
)22 
;22 
}33 
[55 
HttpPost55 
]55 
[66 
Produces66 
(66 
contentType66 
:66 
$str66 -
)66- .
]66. /
[77  
ProducesResponseType77 
(77 
typeof77  
(77  !
Cachorro77! )
)77) *
,77* +
StatusCodes77, 7
.777 8
Status201Created778 H
)77H I
]77I J
[88  
ProducesResponseType88 
(88 
StatusCodes88 %
.88% &(
Status500InternalServerError88& B
)88B C
]88C D
public99 

async99 
Task99 
<99 
IActionResult99 #
>99# $
	PostAsync99% .
(99. /
Cachorro99/ 7
cachorro998 @
)99@ A
{:: 
await;; 
_cachorroContext;; 
.;; 
	Cachorros;; (
.;;( )
AddAsync;;) 1
(;;1 2
cachorro;;2 :
);;: ;
;;;; <
await<< 
_cachorroContext<< 
.<< 
SaveChangesAsync<< /
(<</ 0
)<<0 1
;<<1 2
return>> 
CreatedAtAction>> 
(>> 
nameof>> %
(>>% &
GetByIdAsync>>& 2
)>>2 3
,>>3 4
new>>5 8
{>>9 :
id>>; =
=>>> ?
cachorro>>@ H
.>>H I
Id>>I K
}>>L M
,>>M N
cachorro>>O W
)>>W X
;>>X Y
}?? 
[AA 

HttpDeleteAA 
]AA 
[BB 
ProducesBB 
(BB 
contentTypeBB 
:BB 
$strBB -
)BB- .
]BB. /
[CC  
ProducesResponseTypeCC 
(CC 
StatusCodesCC %
.CC% &
Status204NoContentCC& 8
)CC8 9
]CC9 :
[DD  
ProducesResponseTypeDD 
(DD 
StatusCodesDD %
.DD% &
Status404NotFoundDD& 7
)DD7 8
]DD8 9
[EE  
ProducesResponseTypeEE 
(EE 
StatusCodesEE %
.EE% &(
Status500InternalServerErrorEE& B
)EEB C
]EEC D
publicFF 

asyncFF 
TaskFF 
<FF 
IActionResultFF #
>FF# $
DeleteAsyncFF% 0
(FF0 1
intFF1 4
idFF5 7
)FF7 8
{GG 
varHH 
cachorroHH 
=HH 
awaitHH 
_cachorroContextHH -
.HH- .
	CachorrosHH. 7
.HH7 8
	FindAsyncHH8 A
(HHA B
idHHB D
)HHD E
;HHE F
ifJJ 

(JJ 
cachorroJJ 
==JJ 
nullJJ 
)JJ 
{KK 	
returnLL 
NotFoundLL 
(LL 
)LL 
;LL 
}MM 	
_cachorroContextOO 
.OO 
	CachorrosOO "
.OO" #
RemoveOO# )
(OO) *
cachorroOO* 2
)OO2 3
;OO3 4
awaitPP 
_cachorroContextPP 
.PP 
SaveChangesAsyncPP /
(PP/ 0
)PP0 1
;PP1 2
returnRR 
	NoContentRR 
(RR 
)RR 
;RR 
}SS 
[UU 
HttpPutUU 
]UU 
[VV 
ProducesVV 
(VV 
contentTypeVV 
:VV 
$strVV -
)VV- .
]VV. /
[WW  
ProducesResponseTypeWW 
(WW 
typeofWW  
(WW  !
CachorroWW! )
)WW) *
,WW* +
StatusCodesWW, 7
.WW7 8
Status200OKWW8 C
)WWC D
]WWD E
[XX  
ProducesResponseTypeXX 
(XX 
StatusCodesXX %
.XX% &
Status404NotFoundXX& 7
)XX7 8
]XX8 9
[YY  
ProducesResponseTypeYY 
(YY 
StatusCodesYY %
.YY% &(
Status500InternalServerErrorYY& B
)YYB C
]YYC D
publicZZ 

asyncZZ 
TaskZZ 
<ZZ 
IActionResultZZ #
>ZZ# $
PutAsyncZZ% -
(ZZ- .
intZZ. 1
idZZ2 4
,ZZ4 5
CachorroZZ6 >
cachorroZZ? G
)ZZG H
{[[ 
if\\ 

(\\ 
id\\ 
!=\\ 
cachorro\\ 
.\\ 
Id\\ 
)\\ 
{]] 	
return^^ 

BadRequest^^ 
(^^ 
)^^ 
;^^  
}__ 	
_cachorroContextaa 
.aa 
Entryaa 
(aa 
cachorroaa '
)aa' (
.aa( )
Stateaa) .
=aa/ 0
EntityStateaa1 <
.aa< =
Modifiedaa= E
;aaE F
awaitcc 
_cachorroContextcc 
.cc 
SaveChangesAsynccc /
(cc/ 0
)cc0 1
;cc1 2
returnee 
Okee 
(ee 
cachorroee 
)ee 
;ee 
}ff 
}gg 