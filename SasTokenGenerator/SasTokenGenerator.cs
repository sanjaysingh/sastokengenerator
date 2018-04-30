<html>

<head>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.9-1/crypto-js.min.js" integrity="sha256-u6BamZiW5tCemje2nrteKC2KoLIKX9lKPSpvCkOhamw="
            crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.9-1/hmac-sha256.min.js" integrity="sha256-1Gusk8p9CX01j8sefIYUiC7gBoAryX7+YUUU3iIOvts="
            crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.9-1/enc-base64.min.js" integrity="sha256-7Sn/1Y1J1unxaPqhjNPy5qTKqv9c2rocYsfCzgkwEOc="
            crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
            crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
            crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
            crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
          crossorigin="anonymous">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Azure SAS Generator">
    <meta name="author" content="Sanjay Singh">

    <title>Azure SAS Generator</title>

    <style>
        body {
            overflow-x: hidden;
        }

        #wrapper {
            padding-left: 0;
            -webkit-transition: all 0.5s ease;
            -moz-transition: all 0.5s ease;
            -o-transition: all 0.5s ease;
            transition: all 0.5s ease;
        }

            #wrapper.toggled {
                padding-left: 250px;
            }

        #sidebar-wrapper {
            z-index: 1000;
            position: fixed;
            left: 250px;
            width: 0;
            height: 100%;
            margin-left: -250px;
            overflow-y: auto;
            background: #000;
            -webkit-transition: all 0.5s ease;
            -moz-transition: all 0.5s ease;
            -o-transition: all 0.5s ease;
            transition: all 0.5s ease;
        }

        #wrapper.toggled #sidebar-wrapper {
            width: 250px;
        }

        #asb-sas {
            width: 100%;
            position: absolute;
            padding: 15px;
        }

        #wrapper.toggled #asb-sas {
            position: absolute;
            margin-right: -250px;
        }


        /* Sidebar Styles */

        .sidebar-nav {
            position: absolute;
            top: 0;
            width: 250px;
            margin: 0;
            padding: 0;
            list-style: none;
        }

            .sidebar-nav li {
                text-indent: 20px;
                line-height: 40px;
            }

                .sidebar-nav li a {
                    display: block;
                    text-decoration: none;
                    color: #999999;
                }

                    .sidebar-nav li a:hover {
                        text-decoration: none;
                        color: #fff;
                        background: rgba(255, 255, 255, 0.2);
                    }

                    .sidebar-nav li a:active,
                    .sidebar-nav li a:focus {
                        text-decoration: none;
                    }

            .sidebar-nav > .sidebar-brand {
                height: 65px;
                font-size: 18px;
                line-height: 60px;
            }

                .sidebar-nav > .sidebar-brand a {
                    color: #999999;
                }

                    .sidebar-nav > .sidebar-brand a:hover {
                        color: #fff;
                        background: none;
                    }

        @media(min-width:768px) {
            #wrapper {
                padding-left: 0;
            }

                #wrapper.toggled {
                    padding-left: 250px;
                }

            #sidebar-wrapper {
                width: 0;
            }

            #wrapper.toggled #sidebar-wrapper {
                width: 250px;
            }

            #asb-sas {
                padding: 20px;
                position: relative;
            }

            #wrapper.toggled #asb-sas {
                position: relative;
                margin-right: 0;
            }
        }
    </style>

</head>

<body>

    <div id="wrapper">
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li class="sidebar-brand">
                    <a href="#">
                        Offline SAS Generator
                    </a>
                </li>
                <li>
                    <a href="#">Azure Service Bus</a>
                </li>
                <li>
                    <a href="#">Azure Blob Storage</a>
                </li>
            </ul>
        </div>

        <div id="asb-sas">
            <div class="container-fluid">
                <h1>Azure Service Bus SAS Generator</h1>
                <form id="asbform" onsubmit="return false;">
                    <div class="form-group">
                        <label for="connectionString">Connection String (Primary or Secondary)</label>
                        <input type="text" class="form-control" id="connectionString" placeholder="Endpoint=sb://yourservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yourkey"
                               required>
                    </div>
                    <div class="form-group">
                        <label for="validityInMinutes">Validity (in minutes, hours or days; suffix m, h or d)</label>
                        <input type="text" class="form-control" id="validityInMinutes" value="30m" required>
                    </div>

                    <button type="submit" class="btn btn-primary">Generate</button>
                    <hr />

                    <div class="form-group">
                        <label for="sasConnectionString">SAS Connection String</label>
                        <input class="form-control" type="text" id="sasConnectionString" readonly>
                    </div>

                </form>
                <a href="#menu-toggle" class="btn btn-secondary" id="menu-toggle" hidden>
                    <<
                </a>
            </div>
        </div>


    </div>


    <script>

        (function () {

            function getConnectionStringProperties(connectionString) {
                let parts = connectionString.split(';');
                let propertiesBag = {};
                for (let i = 0; i < parts.length; i++) {
                    let equalindex = parts[i].indexOf("=");
                    let key = parts[i].substring(0, equalindex).trim();
                    let value = parts[i].substring(equalindex + 1).trim();
                    propertiesBag[key] = value;
                }

                return propertiesBag;
            }

            function expandValidityPeriodToMinutes(validityPeriod) {
                if (validityPeriod.endsWith("d")) { // days
                    let days = parseInt(validityPeriod.replace("d", ""));
                    return days * 24 * 60 * 60;
                }
                else if (validityPeriod.endsWith("h")) { // hours
                    let hours = parseInt(validityPeriod.replace("h", ""));
                    return hours * 60 * 60;
                }
                else if (validityPeriod.endsWith("m")) { // minutes
                    let minutes = parseInt(validityPeriod.replace("m", ""));
                    return minutes * 60;
                }

                return parseInt(validityPeriod); // default to seconds
            }

            function createSharedAccessTokenConnectionString(connectionString, validityPeriod) {
                let connectionStringProp = getConnectionStringProperties(connectionString);
                let resourceUri = connectionStringProp['Endpoint'];
                let encodedResourceUri = encodeURIComponent(resourceUri);
                let saName = connectionStringProp['SharedAccessKeyName'];
                let saKey = connectionStringProp['SharedAccessKey'];
                let currDate = new Date();
                let ttl = Math.round(currDate.getTime() / 1000) + expandValidityPeriodToMinutes(validityPeriod);
                let signature = encodedResourceUri + '\n' + ttl;
                let hash = CryptoJS.HmacSHA256(signature, saKey);
                let hashInBase64 = CryptoJS.enc.Base64.stringify(hash);
                let sas = 'SharedAccessSignature sr=' + encodedResourceUri + '&sig=' + encodeURIComponent(hashInBase64) + '&se=' + ttl + '&skn=' + saName;

                let sasConnectionString = 'Endpoint=' + resourceUri + ';' + 'SharedAccessSignature=' + sas;
                for (let prop in connectionStringProp) {
                    if (prop != 'Endpoint' && prop != 'SharedAccessKeyName' && prop != 'SharedAccessKey') {
                        sasConnectionString += ';' + prop + '=' + connectionStringProp[prop];
                    }
                }

                return sasConnectionString;
            }

            window.cryptoUtil = {
                createSharedAccessTokenConnectionString: createSharedAccessTokenConnectionString
            };

            $('#menu-toggle').click(function (e) {
                e.preventDefault();
                $('#wrapper').toggleClass('toggled');
            });

            $('#asbform').on("submit", function (e) {
                let connectionString = $('#connectionString').val();
                let validityPeriod = $('#validityInMinutes').val();
                var sasConnectionString = cryptoUtil.createSharedAccessTokenConnectionString(connectionString, validityPeriod);
                $('#sasConnectionString').val(sasConnectionString);
                e.preventDefault();

            });

        })();


    </script>


</body>

</html>
