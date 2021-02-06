using System;
using System.Collections.Generic;
using System.Text;

namespace PBDesk
{
    public class Pastebin
    {
        public const String
            // Режим приватности
            PASTE_ACCESS_LIMITATION_PUBLIC = "0",
            PASTE_ACCESS_LIMITATION_UNLISTED = "1",
            PASTE_ACCESS_LIMITATION_PRIVATE = "2",
            // Время жизни файла
            PASTE_EXPIRE_DATE_NEVER = "N",
            PASTE_EXPIRE_DATE_TEN_MINUTES = "10M",
            PASTE_EXPIRE_DATE_ONE_HOUR = "1H",
            PASTE_EXPIRE_DATE_ONE_DAY = "1D",
            PASTE_EXPIRE_DATE_ONE_WEEK = "1W",
            PASTE_EXPIRE_DATE_TWO_WEEKS = "2W",
            PASTE_EXPIRE_DATE_ONE_MONTH = "1M",
            PASTE_EXPIRE_DATE_SIX_MONTHS = "6M",
            PASTE_EXPIRE_DATE_ONE_YEAR = "1Y";

        // Формат файла
        public List<String> PasteFormats
        {
            get => new List<String>
            {
                "4cs","6502acme","6502kickass","6502tasm",
                "abap","actionscript","actionscript3","ada",
                "aimms","algol68","apache","applescript",
                "apt_sources","arduino","arm","asm","asp",
                "asymptote","autoconf","autohotkey","autoit",
                "avisynth","awk","bascomavr","bash","basic4gl",
                "dos","bibtex","b3d","blitzbasic","bmx","bnf",
                "boo","bf","c","csharp","c_winapi","cpp","cpp-winapi",
                "cpp-qt","c_loadrunner","caddcl","cadlisp","ceylon","cfdg",
                "c_mac","chaiscript","chapel","cil","clojure","klonec",
                "klonecpp","cmake","cobol","coffeescript","cfm","css",
                "cuesheet","d","dart","dcl","dcpu16","dcs","delphi",
                "oxygene","diff","div","dot","e","ezt","ecmascript",
                "eiffel","email","epc","erlang","euphoria","fsharp",
                "falcon","filemaker","fo","f1","fortran","freebasic",
                "freeswitch","gambas","gml","gdb","gdscript","genero",
                "genie","gettext","go","godot-glsl","groovy","gwbasic",
                "haskell","haxe","hicest","hq9plus","html4strict","html5",
                "icon","idl","ini","inno","intercal","io","ispfpanel","j",
                "java","java5","javascript","jcl","jquery","json","julia",
                "kixtart","kotlin","ksp","latex","ldif","lb","lsl2","lisp","llvm","locobasic",
                "logtalk","lolcode","lotusformulas","lotusscript","lscript","lua",
                "m68k","magiksf","make","mapbasic","markdown","matlab","mercury",
                "metapost","mirc","mmix","mk-61","modula2","modula3","68000devpac",
                "mpasm","mxml","mysql","nagios","netrexx","newlisp","nginx","nim",
                "nsis","oberon2","objeck","objc","ocaml","ocaml-brief","octave","pf",
                "glsl","oorexx","oobas","oracle8","oracle11","oz","parasail","parigp",
                "pascal","pawn","pcre","per","perl","perl6","phix","php","php-brief","pic16",
                "pike","pixelbender","pli","plsql","postgresql","postscript","povray",
                "powerbuilder","powershell","proftpd","progress","prolog","properties",
                "providex","puppet","purebasic","pycon","python","pys60","q","qbasic",
                "qml","rsplus","racket","rails","rbs","rebol","reg","rexx","robots",
                "roff","rpmspec","ruby","gnuplot","rust","sas","scala","scheme","scilab",
                "scl","sdlbasic","smalltalk","smarty","spark","sparql","sqf","sql","sshconfig",
                "standardml","stonescript","sclang","swift","systemverilog","text","tsql","tcl",
                "teraterm","texgraph","thinbasic","typescript","typoscript","unicon","uscript",
                "upc","urbi","vala","vbnet","vbscript","vedit","verilog","vhdl","vim","vb",
                "visualfoxpro","visualprolog","whitespace","whois","winbatch","xbasic",
                "xml","xojo","xorg_conf","xpp","yaml","yara","z80","zxbasic"
            };

            private set {}
        }

        // Уникальный ключ разработчика
        public String ApiDevKey { get; set; }

        // Уникальный ключ пользователя (токен авторизации)
        public String ApiUserKey { get; set; }

        public Pastebin(in String dev_key)
        {
            this.ApiDevKey = dev_key;
            this.ApiUserKey = "";
        }


        
        // Возвращает результат выполнения запроса авторизации
        public Query SignIn(in String username, in String password)
        {
            Query query = new Query
            (
                "https://pastebin.com/api/api_login.php", Query.TYPE_POST,
                new List<Parameter> 
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_user_name", username),
                    new Parameter("api_user_password", password)
                }
            );

            if (query.Status == Query.STATUS_SUCCESS)
                ApiUserKey = Encoding.UTF8.GetString(query.Response.ToArray());

            return query;
        }

        // Возвращает результат запроса о данных пользователя
        public Query UserInfo()
        {
            return new Query
            (
                "https://pastebin.com/api/api_post.php", Query.TYPE_POST,
                new List<Parameter>
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_user_key", this.ApiUserKey),
                    new Parameter("api_option", "userdetails")
                }
            );
        }

        // Возвращает результат запроса на скачивание файла
        public Query LoadFile(String url)
        {
            if (!url.StartsWith("https://"))
                url = "https://pastebin.com" + url;

            return new Query(url, Query.TYPE_GET);
        }

        // Возвращает результат запроса на содержимое текстового файла
        public Query LoadText(String paste_key)
        {
            return new Query
            (
                "https://pastebin.com/api/api_raw.php", Query.TYPE_POST,
                new List<Parameter>
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_user_key", this.ApiUserKey),
                    new Parameter("api_paste_key", paste_key),
                    new Parameter("api_option", "show_paste")
                }
            );
        }

        // Возвращает результат запроса о списке файлов
        public Query PastesList()
        {
            return new Query
            (
                "https://pastebin.com/api/api_post.php", Query.TYPE_POST,
                new List<Parameter>
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_user_key", this.ApiUserKey),
                    new Parameter("api_results_limit", "500"),
                    new Parameter("api_option", "list")
                }
            );
        }

        // Возвращает результат запроса о создании файла
        public Query CreatePaste(in String title, in String text, in String format, 
            in String access, in String expire_date)
        {
            return new Query
            (
                "https://pastebin.com/api/api_post.php", Query.TYPE_POST,
                new List<Parameter>
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_paste_code", text),
                    new Parameter("api_paste_private", access),
                    new Parameter("api_paste_name", title),
                    new Parameter("api_paste_expire_date", expire_date),
                    new Parameter("api_paste_format", format),
                    new Parameter("api_user_key", this.ApiUserKey),
                    new Parameter("api_option", "paste")
                }
            );
        }

        // Возвращает результат запроса об удалении файла
        public Query DeletePaste(in String paste_key)
        {
            return new Query
            (
                "https://pastebin.com/api/api_post.php", Query.TYPE_POST,
                new List<Parameter>
                {
                    new Parameter("api_dev_key", this.ApiDevKey),
                    new Parameter("api_user_key", this.ApiUserKey),
                    new Parameter("api_paste_key", paste_key),
                    new Parameter("api_option", "delete")
                }
            );
        }
    }
}
