﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rayner.Data
{
    class Enumerables
    {
        public enum Day
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }
        public enum ShortDay
        {
            Mon = 1,
            Tue = 2,
            Wed = 3,
            Thu = 4,
            Fri = 5,
            Sat = 6,
            Sun = 7
        }
        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
        public enum ShortMonth
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }
        public enum Currency
        {
            AED,//United Arab Emirates Dirham
            AFN,//Afghanistan Afghani
            ALL,//Albania Lek
            AMD,//Armenia Dram
            ANG,//Netherlands Antilles Guilder
            AOA,//Angola Kwanza
            ARS,//Argentina Peso
            AUD,//Australia Dollar
            AWG,//Aruba Guilder
            AZN,//Azerbaijan New Manat
            BAM,//Bosnia and Herzegovina Convertible Marka
            BBD,//Barbados Dollar
            BDT,//Bangladesh Taka
            BGN,//Bulgaria Lev
            BHD,//Bahrain Dinar
            BIF,//Burundi Franc
            BMD,//Bermuda Dollar
            BND,//Brunei Darussalam Dollar
            BOB,//Bolivia Boliviano
            BRL,//Brazil Real
            BSD,//Bahamas Dollar
            BTN,//Bhutan Ngultrum
            BWP,//Botswana Pula
            BYR,//Belarus Ruble
            BZD,//Belize Dollar
            CAD,//Canada Dollar
            CDF,//Congo/Kinshasa Franc
            CHF,//Switzerland Franc
            CLP,//Chile Peso
            CNY,//China Yuan Renminbi
            COP,//Colombia Peso
            CRC,//Costa Rica Colon
            CUC,//Cuba Convertible Peso
            CUP,//Cuba Peso
            CVE,//Cape Verde Escudo
            CZK,//Czech Republic Koruna
            DJF,//Djibouti Franc
            DKK,//Denmark Krone
            DOP,//Dominican Republic Peso
            DZD,//Algeria Dinar
            EGP,//Egypt Pound
            ERN,//Eritrea Nakfa
            ETB,//Ethiopia Birr
            EUR,//Euro Member Countries
            FJD,//Fiji Dollar
            FKP,//Falkland Islands (Malvinas) Pound
            GBP,//United Kingdom Pound
            GEL,//Georgia Lari
            GGP,//Guernsey Pound
            GHS,//Ghana Cedi
            GIP,//Gibraltar Pound
            GMD,//Gambia Dalasi
            GNF,//Guinea Franc
            GTQ,//Guatemala Quetzal
            GYD,//Guyana Dollar
            HKD,//Hong Kong Dollar
            HNL,//Honduras Lempira
            HRK,//Croatia Kuna
            HTG,//Haiti Gourde
            HUF,//Hungary Forint
            IDR,//Indonesia Rupiah
            ILS,//Israel Shekel
            IMP,//Isle of Man Pound
            INR,//India Rupee
            IQD,//Iraq Dinar
            IRR,//Iran Rial
            ISK,//Iceland Krona
            JEP,//Jersey Pound
            JMD,//Jamaica Dollar
            JOD,//Jordan Dinar
            JPY,//Japan Yen
            KES,//Kenya Shilling
            KGS,//Kyrgyzstan Som
            KHR,//Cambodia Riel
            KMF,//Comoros Franc
            KPW,//Korea (North) Won
            KRW,//Korea (South) Won
            KWD,//Kuwait Dinar
            KYD,//Cayman Islands Dollar
            KZT,//Kazakhstan Tenge
            LAK,//Laos Kip
            LBP,//Lebanon Pound
            LKR,//Sri Lanka Rupee
            LRD,//Liberia Dollar
            LSL,//Lesotho Loti
            LTL,//Lithuania Litas
            LVL,//Latvia Lat
            LYD,//Libya Dinar
            MAD,//Morocco Dirham
            MDL,//Moldova Leu
            MGA,//Madagascar Ariary
            MKD,//Macedonia Denar
            MMK,//Myanmar (Burma) Kyat
            MNT,//Mongolia Tughrik
            MOP,//Macau Pataca
            MRO,//Mauritania Ouguiya
            MUR,//Mauritius Rupee
            MVR,//Maldives (Maldive Islands) Rufiyaa
            MWK,//Malawi Kwacha
            MXN,//Mexico Peso
            MYR,//Malaysia Ringgit
            MZN,//Mozambique Metical
            NAD,//Namibia Dollar
            NGN,//Nigeria Naira
            NIO,//Nicaragua Cordoba
            NOK,//Norway Krone
            NPR,//Nepal Rupee
            NZD,//New Zealand Dollar
            OMR,//Oman Rial
            PAB,//Panama Balboa
            PEN,//Peru Nuevo Sol
            PGK,//Papua New Guinea Kina
            PHP,//Philippines Peso
            PKR,//Pakistan Rupee
            PLN,//Poland Zloty
            PYG,//Paraguay Guarani
            QAR,//Qatar Riyal
            RON,//Romania New Leu
            RSD,//Serbia Dinar
            RUB,//Russia Ruble
            RWF,//Rwanda Franc
            SAR,//Saudi Arabia Riyal
            SBD,//Solomon Islands Dollar
            SCR,//Seychelles Rupee
            SDG,//Sudan Pound
            SEK,//Sweden Krona
            SGD,//Singapore Dollar
            SHP,//Saint Helena Pound
            SLL,//Sierra Leone Leone
            SOS,//Somalia Shilling
            SPL,//Seborga Luigino
            SRD,//Suriname Dollar
            STD,//São Tomé and Príncipe Dobra
            SVC,//El Salvador Colon
            SYP,//Syria Pound
            SZL,//Swaziland Lilangeni
            THB,//Thailand Baht
            TJS,//Tajikistan Somoni
            TMT,//Turkmenistan Manat
            TND,//Tunisia Dinar
            TOP,//Tonga Pa'anga
            TRY,//Turkey Lira
            TTD,//Trinidad and Tobago Dollar
            TVD,//Tuvalu Dollar
            TWD,//Taiwan New Dollar
            TZS,//Tanzania Shilling
            UAH,//Ukraine Hryvna
            UGX,//Uganda Shilling
            USD,//United States Dollar
            UYU,//Uruguay Peso
            UZS,//Uzbekistan Som
            VEF,//Venezuela Bolivar
            VND,//Viet Nam Dong
            VUV,//Vanuatu Vatu
            WST,//Samoa Tala
            XAF,//Communauté Financière Africaine (BEAC) CFA Franc BEAC
            XCD,//East Caribbean Dollar
            XDR,//International Monetary Fund (IMF) Special Drawing Rights
            XOF,//Communauté Financière Africaine (BCEAO) Franc
            XPF,//Comptoirs Français du Pacifique (CFP) Franc
            YER,//Yemen Rial
            ZAR,//South Africa Rand
            ZMW,//Zambia Kwacha
            ZWD,//Zimbabwe Dollar
        }
    }
}