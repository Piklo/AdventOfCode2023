﻿namespace AdventOfCode2023.Day09;

public static class Input09
{
    public const string Data = """
        3 10 23 46 99 234 563 1310 2904 6131 12351 23745 43470 75464 123501 189097 268370 349700 418439 484617 669380
        16 41 77 119 171 265 488 1017 2162 4417 8519 15515 26837 44385 70618 108653 162372 236537 336913 470399 645167
        20 45 91 182 351 648 1157 2027 3543 6296 11556 22009 43088 85209 167316 322244 604526 1101399 1947905 3347136 5596837
        24 50 87 141 223 341 487 621 653 420 -352 -2121 -5670 -12365 -24598 -46505 -85074 -151786 -264963 -453031 -758943
        13 31 76 172 351 645 1075 1649 2399 3508 5604 10347 21558 47460 105396 232221 507493 1104469 2398816 5191706 11149877
        11 26 41 56 71 86 101 116 131 146 161 176 191 206 221 236 251 266 281 296 311
        15 29 51 84 133 204 310 490 840 1545 2898 5314 9419 16451 29509 56732 118481 262393 593397 1331440 2919341
        15 25 37 52 92 226 605 1507 3400 7055 13792 26042 48618 91547 176291 349138 709201 1464905 3043603 6296140 12864564
        7 10 18 37 73 132 220 343 507 718 982 1305 1693 2152 2688 3307 4015 4818 5722 6733 7857
        15 38 84 178 356 676 1258 2368 4561 8898 17252 32718 60142 106784 183130 303868 489043 765406 1167972 1741802 2544024
        6 1 -1 4 18 43 88 187 448 1186 3263 8896 23446 59130 142286 326871 718410 1514791 3073295 6017268 11401122
        15 29 41 54 79 135 249 456 799 1329 2105 3194 4671 6619 9129 12300 16239 21061 26889 33854 42095
        19 32 61 116 209 354 567 866 1271 1804 2489 3352 4421 5726 7299 9174 11387 13976 16981 20444 24409
        6 20 44 78 122 176 240 314 398 492 596 710 834 968 1112 1266 1430 1604 1788 1982 2186
        16 30 54 91 153 265 478 906 1811 3777 8045 17148 36139 75040 153808 312341 630150 1263728 2514908 4951321 9611313
        13 38 88 174 309 517 845 1386 2334 4116 7690 15178 31151 65158 136598 283958 582099 1174186 2329820 4549050 8744617
        24 34 44 54 64 74 84 94 104 114 124 134 144 154 164 174 184 194 204 214 224
        9 13 27 63 139 273 489 854 1568 3142 6746 14925 33112 72770 157638 335518 699411 1423691 2823509 5448867 10228929
        10 10 27 74 165 327 637 1304 2826 6271 13771 29395 60703 121520 236914 452294 850626 1586416 2955103 5536876 10493273
        4 -2 1 20 72 195 466 1039 2234 4749 10146 21906 47613 103336 222285 471798 986484 2032184 4127207 8266676 16326242
        26 37 48 59 70 81 92 103 114 125 136 147 158 169 180 191 202 213 224 235 246
        22 29 39 66 134 284 585 1149 2150 3851 6669 11402 19995 37786 79284 181567 433019 1031652 2399292 5400601 11759053
        15 30 58 119 247 501 993 1937 3727 7076 13313 25067 47809 93158 185649 376132 767743 1565630 3171448 6361747 12621939
        3 6 9 15 33 80 178 345 578 825 942 630 -654 -3819 -10303 -22286 -42963 -76888 -130401 -212151 -333729
        17 25 47 101 219 463 964 2011 4225 8871 18399 37384 74212 144276 276417 526495 1006445 1945905 3819619 7602107 15258621
        18 29 46 68 95 128 169 221 288 375 488 634 821 1058 1355 1723 2174 2721 3378 4160 5083
        7 14 23 38 77 194 511 1260 2835 5854 11231 20258 34697 56882 89831 137368 204255 296334 420679 585758 801605
        22 38 69 135 264 494 877 1486 2430 3889 6192 9989 16665 29438 56335 117945 266418 629260 1504963 3562351 8239882
        26 53 99 180 322 573 1030 1882 3470 6365 11465 20112 34230 56485 90468 140902 213874 317093 460175 654956 915834
        15 23 35 61 122 257 543 1142 2402 5056 10594 21958 44885 90585 181120 360055 713057 1406833 2761469 5383323 10407444
        10 8 4 13 68 227 585 1295 2609 4966 9184 16876 31349 59530 115990 231038 466366 944412 1903010 3799003 7512836
        5 16 47 115 252 511 974 1776 3164 5606 9944 17535 30228 49864 76748 106236 122251 86280 -79663 -517365 -1464656
        15 24 45 100 222 456 857 1485 2397 3636 5217 7110 9220 11364 13245 14423 14283 12000 6501 -3576 -19926
        9 28 63 129 262 526 1024 1924 3520 6369 11584 21431 40508 78061 152598 301239 598775 1196146 2396433 4800625 9578422
        9 8 16 61 188 456 945 1788 3243 5820 10478 18907 33910 59900 103527 174450 286269 457632 713532 1086809 1619872
        17 36 59 89 150 315 760 1851 4280 9300 19180 38125 74110 142422 272337 519607 989951 1883736 3581545 6807641 12938466
        7 20 46 97 195 378 708 1274 2191 3626 5945 10183 19205 40164 89187 199648 435935 915304 1841256 3552893 6595927
        10 5 -5 -20 -40 -65 -95 -130 -170 -215 -265 -320 -380 -445 -515 -590 -670 -755 -845 -940 -1040
        12 15 14 8 -5 -33 -80 -91 201 1614 6181 18353 47069 109209 235297 479044 933854 1762589 3253152 5924174 10725971
        17 28 54 115 241 485 951 1856 3664 7364 15036 30992 64033 131772 268582 539580 1064191 2054280 3873614 7127525 12794077
        3 18 41 76 144 297 646 1422 3108 6716 14355 30387 63785 132963 275685 569338 1172097 2405486 4917217 9995922 20165782
        -2 -11 -18 -18 -9 20 110 363 996 2452 5649 12567 27667 61305 137695 312640 711010 1601959 3542704 7641380 16018623
        10 26 64 139 273 495 841 1354 2084 3088 4430 6181 8419 11229 14703 18940 24046 30134 37324 45743 55525
        14 24 44 81 144 259 502 1068 2419 5602 12910 29200 64433 138451 289794 591687 1180468 2305044 4410912 8279435 15253110
        -5 -6 -7 -8 -9 -10 -11 -12 -13 -14 -15 -16 -17 -18 -19 -20 -21 -22 -23 -24 -25
        7 8 28 92 250 591 1258 2478 4629 8371 14868 26113 45312 77128 127213 199638 289163 362090 313624 -120434 -1536674
        13 23 37 68 128 234 434 866 1882 4303 9920 22420 48995 102986 208023 404246 757331 1371199 2405455 4098788 6799762
        12 20 25 36 65 121 199 260 198 -210 -1375 -3992 -9165 -18565 -34625 -60776 -101728 -163800 -255303 -386980 -572507
        19 27 30 35 72 205 554 1345 3019 6463 13486 27773 56756 115227 232224 463967 917739 1795083 3468214 6612095 12427528
        22 31 33 30 26 34 98 328 956 2458 5868 13557 30990 70339 157357 343649 727458 1487369 2934979 5594648 10321002
        -2 -8 -10 11 87 272 656 1383 2671 4828 8253 13407 20738 30548 42801 56891 71420 84080 91792 91331 80761
        -9 -10 -2 28 101 258 583 1236 2495 4806 8840 15556 26269 42722 67161 102412 151959 220022 311634 432716 590149
        9 22 58 135 291 603 1213 2361 4425 7968 13792 22999 37059 57885 87915 130201 188505 267402 372390 510007 687955
        11 16 36 88 195 396 773 1496 2887 5512 10331 18975 34281 61306 109164 194191 345147 611416 1075470 1871226 3210351
        11 25 42 61 81 101 120 137 151 161 166 165 157 141 116 81 35 -23 -94 -179 -279
        12 13 27 81 215 482 948 1692 2806 4395 6577 9483 13257 18056 24050 31422 40368 51097 63831 78805 96267
        23 47 91 161 263 403 587 821 1111 1463 1883 2377 2951 3611 4363 5213 6167 7231 8411 9713 11143
        22 40 68 119 215 382 647 1044 1639 2599 4375 8181 17211 39616 95503 232744 561299 1324998 3046759 6814429 14831782
        5 8 13 32 102 306 802 1860 3907 7580 13787 23776 39212 62262 95688 142948 208305 296944 415097 570176 770914
        24 34 52 87 143 225 368 713 1661 4151 10156 23609 52208 110966 229042 462397 916262 1783392 3406732 6378571 11692653
        12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        10 25 42 73 160 391 917 1966 3841 6888 11440 17797 26403 38542 58109 95332 173740 342203 694526 1399873 2748242
        7 15 40 93 196 393 767 1475 2827 5458 10690 21284 43001 87846 180779 373417 771448 1588223 3247376 6576762 13174273
        17 21 36 70 134 258 514 1042 2075 3959 7164 12282 20008 31100 46314 66310 91525 122009 157220 195774 235146
        5 24 67 143 257 409 605 887 1384 2378 4378 8235 15481 29448 58482 123927 277779 638304 1456805 3235439 6924821
        -4 -13 -31 -65 -116 -170 -189 -102 204 893 2189 4385 7852 13048 20527 30948 45084 63831 88217 119411 158732
        9 3 -7 -13 14 145 522 1405 3256 6883 13661 25826 46797 81415 135892 217132 330915 478219 648689 809941 891008
        19 26 42 77 157 335 694 1332 2321 3644 5135 6474 7319 7702 8947 15807 41799 122946 352368 962939 2513289
        24 43 72 128 246 498 1023 2081 4170 8292 16532 33246 67397 137051 277976 560104 1119120 2217113 4358724 8512176 16525692
        14 25 36 59 130 316 725 1526 2997 5655 10608 20453 41406 88013 192938 426237 931696 1993231 4154260 8432537 16713850
        19 44 81 141 261 519 1064 2184 4456 9055 18341 36886 73134 141888 267766 489635 865785 1479206 2441737 3895019 6005051
        22 27 31 48 113 303 773 1810 3906 7845 14799 26457 45305 75383 124229 207355 357574 642911 1198799 2282910 4364441
        7 12 24 52 116 259 557 1127 2133 3790 6366 10182 15610 23069 33019 45953 62387 82848 107860 137928 173520
        -1 6 29 91 228 492 956 1715 2874 4511 6600 8876 10621 10347 5349 -8902 -39559 -97428 -198265 -364383 -626614
        22 27 43 86 173 322 552 883 1336 1933 2697 3652 4823 6236 7918 9897 12202 14863 17911 21378 25297
        4 3 -4 -8 14 95 281 653 1380 2815 5646 11114 21310 39563 70931 122807 205652 333867 526816 810012 1216478
        10 9 17 50 133 301 600 1088 1836 2929 4467 6566 9359 12997 17650 23508 30782 39705 50533 63546 79049
        7 0 -9 -20 -21 30 229 772 2060 4936 11193 24608 52958 111845 231915 472723 950241 1893280 3761743 7495716 15035137
        10 21 26 38 82 205 499 1145 2494 5204 10445 20164 37385 66582 114525 193166 329149 591406 1162719 2509549 5757819
        10 25 54 96 157 254 412 662 1069 1849 3673 8304 19770 46342 103661 219442 440276 841153 1538440 2707168 4603611
        23 38 61 112 231 499 1075 2262 4625 9194 17795 33562 61693 110523 192997 328636 546099 886454 1407281 2187740 3334747
        13 24 59 145 330 706 1458 2953 5896 11603 22474 42792 80027 146887 264431 466642 806951 1367306 2270493 3696539 5904160
        10 18 27 42 73 135 248 437 732 1168 1785 2628 3747 5197 7038 9335 12158 15582 19687 24558 30285
        0 20 69 166 341 646 1172 2068 3551 5883 9275 13668 18357 21505 19801 8917 -13953 -43392 -52008 34010 375042
        17 15 9 -5 -24 -12 147 721 2238 5664 12732 26593 53145 103800 201325 392204 772513 1540933 3104557 6284571 12706664
        0 10 34 77 151 285 557 1156 2479 5267 10785 21054 39148 69576 118778 195775 313026 487560 742468 1108859 1628405
        12 16 20 24 28 32 36 40 44 48 52 56 60 64 68 72 76 80 84 88 92
        11 29 57 92 131 171 209 242 267 281 281 264 227 167 81 -34 -181 -363 -583 -844 -1149
        -1 -1 3 23 82 226 539 1155 2271 4195 7529 13721 26479 55018 120964 272252 610107 1340413 2870991 5996513 12252244
        9 6 -1 -16 -41 -72 -95 -73 97 692 2391 6721 16930 39768 89256 194718 417549 884978 1855267 3838446 7811229
        6 5 4 13 52 160 422 1028 2379 5254 11059 22216 42852 80173 147371 269868 498718 939273 1812188 3582057 7224622
        13 33 75 152 286 523 960 1788 3352 6226 11298 19857 33671 55042 86821 132363 195399 279799 389197 526446 692868
        10 19 30 59 134 295 594 1095 1874 3019 4630 6819 9710 13439 18154 24015 31194 39875 50254 62539 76950
        19 27 43 89 213 499 1078 2146 3995 7063 12009 19819 31949 50511 78508 120124 181075 269027 394087 569373 811669
        -2 -3 -11 -28 -41 -2 197 748 1943 4177 7952 13966 23563 40276 74198 153035 348067 832077 2003716 4746046 10948462
        19 30 60 123 242 466 905 1799 3642 7387 14763 28740 54183 98741 174022 297110 492485 794412 1249870 1922097 2894832
        0 7 27 81 213 494 1027 1968 3587 6398 11380 20291 36062 63297 109090 184848 310794 526609 914641 1646749 3072763
        17 32 58 111 237 524 1118 2263 4402 8395 15926 30177 56831 105418 190966 336018 573779 955502 1571274 2606855 4486445
        15 20 35 78 181 404 862 1782 3631 7396 15165 31276 64500 132042 266623 528588 1025907 1946124 3605771 6524482 11532963
        20 46 93 176 318 563 997 1767 3094 5303 8946 15186 26784 50386 101536 215309 468375 1024083 2223578 4768355 10082757
        3 8 24 64 151 325 657 1282 2478 4835 9568 19016 37316 71128 130115 226735 375087 589848 890362 1324626 2047999
        7 15 32 60 103 162 237 361 716 1925 5685 16012 41518 99340 221600 465601 929365 1774603 3259782 5786628 9964185
        1 -7 -17 -33 -67 -146 -322 -676 -1284 -2080 -2510 -817 7300 31141 89649 220744 501079 1088781 2315289 4877757 10228491
        12 27 59 115 218 416 793 1483 2697 4796 8487 15311 28807 57252 120069 262580 589026 1333781 3008755 6696087 14606600
        24 40 71 124 198 282 369 512 975 2574 7361 19879 49309 112942 241541 487311 935370 1719812 3045675 5218374 8682432
        17 18 13 -6 -37 -53 13 283 949 2288 4677 8608 14703 23729 36613 54457 78553 110398 151709 204438 270787
        -1 2 12 38 91 184 332 552 863 1286 1844 2562 3467 4588 5956 7604 9567 11882 14588 17726 21339
        23 39 66 122 249 520 1037 1931 3386 5729 9665 16795 30647 58615 115552 230558 460253 915439 1815044 3593968 7113449
        -7 -2 9 33 88 203 418 784 1363 2228 3463 5163 7434 10393 14168 18898 24733 31834 40373 50533 62508
        16 25 31 42 72 146 325 770 1883 4604 11028 25668 57977 127225 271612 564742 1144514 2262427 4365693 8231006 15178118
        17 35 59 94 145 217 318 474 786 1597 3911 10355 27266 69022 166670 384444 850191 1809395 3717867 7395824 14276711
        12 13 17 24 34 47 63 82 104 129 157 188 222 259 299 342 388 437 489 544 602
        0 -1 -6 -19 -44 -85 -146 -231 -344 -489 -670 -891 -1156 -1469 -1834 -2255 -2736 -3281 -3894 -4579 -5340
        5 16 32 70 173 428 985 2069 3988 7168 12293 20696 35238 62028 113480 213375 404799 762064 1407990 2538234 4454699
        7 13 34 89 211 458 932 1814 3444 6520 12583 25131 52010 110221 235027 496322 1026725 2067887 4044160 7676197 14151365
        10 22 35 46 52 50 37 10 -34 -98 -185 -298 -440 -614 -823 -1070 -1358 -1690 -2069 -2498 -2980
        15 28 60 130 266 504 891 1497 2434 3877 6097 9579 15462 26884 52455 114159 263677 613630 1393790 3047140 6387030
        28 36 49 85 173 364 756 1547 3145 6394 13039 26691 54844 113093 233903 484671 1004561 2078906 4288030 8801645 17953478
        10 18 18 5 -11 9 153 589 1610 3694 7578 14343 25505 43105 69789 108867 164338 240866 343690 478449 650901
        3 8 13 30 83 220 536 1207 2543 5096 9920 19187 37529 74714 150587 303628 605011 1180704 2244943 4149356 7453119
        6 23 53 112 234 491 1028 2127 4326 8646 17029 33173 64095 123050 235114 448303 856506 1647425 3201837 6293946 12482396
        13 34 69 132 260 532 1099 2246 4522 8985 17614 33936 63893 116917 207086 354152 584375 932072 1446071 2214064 3438654
        13 30 52 89 161 302 580 1153 2402 5216 11564 25606 55842 119333 250156 516518 1055280 2140619 4317945 8659852 17246368
        7 18 31 46 63 82 103 126 151 178 207 238 271 306 343 382 423 466 511 558 607
        21 48 101 194 354 639 1161 2117 3836 6861 12108 21193 37129 65854 119643 224743 438199 883902 1827123 3822840 7999884
        11 13 22 57 146 334 718 1536 3347 7361 16032 34149 70916 144028 287775 569230 1120532 2202854 4331783 8519402 16733123
        -2 11 51 137 300 602 1181 2348 4786 9941 20756 42992 87522 174193 338136 639750 1179934 2122363 3724473 6377975 10657624
        7 13 28 51 73 73 14 -154 -459 -781 -510 2274 12653 42918 121184 309218 738163 1677669 3664992 7737833 15840617
        -9 -16 -23 -13 49 221 596 1330 2694 5150 9448 16766 29011 49657 86117 156061 303173 634244 1402195 3183669 7243449
        20 35 56 83 116 155 200 251 308 371 440 515 596 683 776 875 980 1091 1208 1331 1460
        7 1 4 39 141 367 815 1651 3143 5701 9922 16639 26973 42387 64741 96347 140023 199145 277696 380311 512317
        24 45 72 111 185 351 727 1527 3112 6095 11590 21775 41076 78559 152743 301440 602189 1214813 2469043 5041085 10300040
        -5 -4 2 13 38 109 306 798 1900 4149 8435 16316 30843 58592 114261 230351 476543 997368 2084774 4318733 8843090
        12 18 27 47 95 215 513 1216 2769 5998 12388 24553 47010 87411 158436 280606 486338 825634 1373873 2242259 3591569
        4 24 68 149 287 515 885 1474 2390 3778 5826 8771 12905 18581 26219 36312 49432 66236 87472 113985 146723
        0 -10 -20 -25 -20 0 40 105 200 330 500 715 980 1300 1680 2125 2640 3230 3900 4655 5500
        -8 -10 3 58 204 518 1123 2244 4337 8347 16210 31856 63266 126690 255089 514413 1033714 2058624 4042777 7798770 14739772
        15 18 30 58 120 251 502 934 1613 2627 4196 7075 13729 31293 78265 198410 487727 1143860 2552398 5431564 11066378
        8 15 48 121 259 521 1037 2071 4138 8229 16234 31705 61201 116694 220077 412042 770044 1444583 2730844 5205533 9978815
        10 20 46 90 164 317 671 1465 3113 6296 12131 22494 40621 72173 127030 222177 386164 665764 1135620 1911866 3170930
        18 23 24 32 80 243 671 1651 3722 7886 16006 31591 61405 118835 230952 453097 898238 1794181 3591256 7158078 14125706
        29 51 92 167 309 595 1178 2335 4553 8686 16235 29845 54198 97633 175070 313184 559297 996161 1765722 3106111 5407527
        12 12 4 -21 -76 -178 -348 -611 -996 -1536 -2268 -3233 -4476 -6046 -7996 -10383 -13268 -16716 -20796 -25581 -31148
        0 9 35 98 232 488 936 1674 2877 4958 8966 17413 35803 75231 156529 316559 617390 1159247 2098285 3670420 6222642
        13 21 32 49 85 182 447 1112 2635 5878 12439 25300 50113 97733 189126 364748 702329 1350459 2591722 4960343 9458373
        9 19 39 86 189 395 789 1533 2933 5553 10424 19471 36446 68985 133049 262273 527277 1075055 2208489 4544904 9327119
        19 36 72 149 295 545 946 1563 2481 3802 5652 8243 12077 18443 30510 55765 111767 240144 540160 1245849 2894059
        15 29 72 172 384 804 1583 2941 5181 8703 14018 21762 32710 47790 68097 94907 129691 174129 230124 299816 385596
        25 35 55 98 193 403 842 1697 3271 6073 10991 19594 34619 60709 105478 180989 305741 507271 825487 1316858 2059597
        6 8 10 12 14 16 18 20 22 24 26 28 30 32 34 36 38 40 42 44 46
        8 11 15 32 76 169 370 839 1956 4538 10240 22298 46904 95789 191261 376486 737120 1447065 2863661 5719920 11499172
        -8 -2 13 45 122 303 686 1418 2735 5097 9533 18373 36617 74274 150096 297232 571434 1062560 1910237 3324669 5613700
        13 23 33 43 53 63 73 83 93 103 113 123 133 143 153 163 173 183 193 203 213
        18 43 77 122 190 318 594 1204 2519 5250 10708 21215 40721 75691 136335 238263 404656 669053 1078863 1699720 2620808
        8 16 28 42 62 98 176 371 883 2196 5408 12934 30042 68225 152478 336535 733710 1577404 3336844 6934362 14147986
        8 18 25 29 27 19 31 159 645 2027 5484 13657 32508 75226 169850 373203 794966 1637312 3257507 6263301 11653801
        6 24 56 106 178 279 424 638 944 1313 1529 884 -2444 -12568 -37949 -94582 -209847 -424059 -779987 -1274723 -1714327
        -2 13 45 110 245 522 1077 2173 4319 8468 16321 30775 56579 101338 177239 304520 519289 891865 1569433 2872703 5509044
        17 26 47 86 160 319 683 1500 3231 6668 13091 24470 43718 75001 124111 198908 309837 470526 698471 1015814 1450220
        -3 -1 8 31 81 182 388 841 1902 4409 10163 22832 49615 104267 212544 421952 819143 1560767 2927518 5416973 9898961
        13 20 38 80 163 311 565 1001 1756 3062 5289 9000 15024 24557 39306 61697 95175 144632 217008 322120 473785
        28 39 47 63 118 277 660 1478 3107 6261 12404 24678 49842 102075 210163 430999 875464 1759681 3509315 6974263 13868272
        20 37 63 92 127 189 323 614 1250 2702 6132 14201 32571 72666 156840 328295 670484 1345532 2670978 5274306 10406489
        12 14 31 87 219 479 939 1706 2953 4972 8273 13827 23743 43064 84079 175767 383139 845371 1850192 3980360 8406944
        -8 -12 -15 -8 21 80 174 332 700 1782 4988 13797 36140 89197 208948 469000 1017273 2146494 4427414 8955718 17799720
        9 20 36 52 63 64 50 16 -43 -132 -256 -420 -629 -888 -1202 -1576 -2015 -2524 -3108 -3772 -4521
        22 38 71 131 225 358 542 820 1318 2363 4763 10452 23873 54719 123012 268101 564392 1149494 2277273 4423811 8507611
        15 25 48 99 193 350 610 1062 1889 3437 6341 11804 22265 42999 85871 177948 380787 832437 1835974 4039605 8789881
        -3 12 53 138 295 568 1034 1838 3254 5784 10314 18356 32418 56560 97213 164360 273203 446468 717531 1134582 1766081
        9 18 48 126 296 625 1223 2292 4229 7838 14770 28423 55712 110379 218873 430309 832633 1577898 2920516 5273516 9289232
        12 23 37 57 99 199 425 903 1868 3751 7323 13958 26187 48985 92882 181485 369228 781655 1702709 3754963 8254611
        24 48 95 177 306 499 786 1221 1896 2958 4629 7229 11202 17145 25840 38289 55752 79788 112299 155577 212354
        4 5 7 10 14 19 25 32 40 49 59 70 82 95 109 124 140 157 175 194 214
        7 9 13 26 70 197 515 1225 2669 5389 10197 18256 31172 51097 80843 124007 185107 269729 384685 538182 740002
        15 28 44 60 73 80 78 64 35 -12 -80 -172 -291 -440 -622 -840 -1097 -1396 -1740 -2132 -2575
        17 38 65 108 202 432 975 2169 4632 9480 18737 36101 68345 127819 236819 435057 792171 1428238 2546689 4485974 7798892
        20 30 44 71 137 292 617 1231 2305 4124 7316 13509 26907 57623 128106 284692 617246 1291102 2597120 5027743 9389545
        9 14 29 68 169 402 877 1761 3321 6024 10750 19215 34763 63774 118054 218728 402353 730210 1302027 2275734 3895261
        9 23 39 56 72 89 136 336 1061 3246 8987 22668 53123 117887 251707 523689 1071642 2169768 4358940 8690267 17165991
        16 30 59 112 213 412 806 1582 3108 6124 12128 24119 47957 94734 184721 353659 662384 1210994 2158945 3752554 6361325
        7 12 38 108 255 520 957 1664 2871 5128 9648 18872 37335 72924 138631 254916 452807 777876 1295242 2095764 3303599
        3 10 35 103 265 612 1288 2502 4539 7770 12661 19781 29809 43540 61890 85900 116739 155706 204231 263875 336329
        16 29 53 95 170 319 639 1343 2894 6296 13677 29364 61728 126168 249707 477790 884004 1583583 2751717 4647853 7647358
        16 40 69 105 168 319 707 1653 3787 8255 17021 33324 62443 113114 200286 350512 612477 1077901 1924644 3509430 6572577
        0 11 34 77 173 410 979 2241 4814 9681 18315 32806 55976 91537 144597 223435 344712 546499 917076 1652791 3165715
        9 14 36 80 146 231 333 456 625 941 1740 3982 10126 26022 64897 155516 358321 796136 1710316 3559564 7187714
        11 36 85 172 312 525 853 1393 2354 4170 7765 15200 31175 66259 143335 309641 658037 1362816 2737597 5325692 10036938
        6 9 16 38 98 240 543 1150 2342 4719 9594 19762 40874 83726 167865 327018 616966 1126613 1993140 3422286 5714962
        16 18 20 22 24 26 28 30 32 34 36 38 40 42 44 46 48 50 52 54 56
        5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
        16 22 28 34 40 46 52 58 64 70 76 82 88 94 100 106 112 118 124 130 136
        -3 0 10 37 93 197 388 759 1537 3240 6939 14638 29755 57639 105989 184948 306525 482848 722568 1024515 1367449
        10 20 28 37 65 165 456 1173 2761 6065 12705 25772 51038 98940 187675 347830 629068 1109498 1908474 3203695 5253615
        24 40 59 86 145 285 584 1165 2249 4287 8253 16271 32930 67962 141480 293768 602766 1213994 2389815 4587764 8581295
        14 24 49 96 172 302 575 1237 2854 6572 14505 30286 59820 112282 201407 347123 577582 931648 1461905 2238252 3352156
        -1 14 44 89 149 224 314 419 539 674 824 989 1169 1364 1574 1799 2039 2294 2564 2849 3149
        14 15 17 21 40 117 357 989 2491 5837 12960 27569 56511 111931 214554 398493 718076 1257283 2142491 3559341 5774666
        4 14 44 117 269 547 1003 1682 2609 3791 5262 7215 10313 16436 30590 65824 155350 380532 931308 2228761 5160433
        12 9 6 3 0 -3 -6 -9 -12 -15 -18 -21 -24 -27 -30 -33 -36 -39 -42 -45 -48
        20 35 54 78 121 218 424 801 1386 2126 2773 2790 1505 -770 1178 28420 145017 519925 1559927 4182072 10352394
        """;
}
