﻿public partial class MainWindow : Gtk.Window
{
	protected char [] GetCodePage (int num, string name = "none", string mode = "export")
	{
		if (mode == "export") {
			if (num == 0)
				return ("王国暦６１９年２月帝都レオグラードは人々その狂信的な政治体制に恐れおいてた東部三を手中収めゼフロス将軍幼マナリ擁しサキア要塞陣構え配下万兵らび彼幕う多く民訴こ対ァイルバムタン守り二残自六率目指" +
				"ベ子る由ヴェ総勢ユト・ハ方面か伺あィボニシノ一地圧帰城途上っ、立ち寄村でテ驚べき情報がもさ教皇ウヌズ団支脱出妃とす助け求仰ぐ草新派心旧間激抗争始ま３奪回進窺").ToCharArray ();
			if (num == 1)
				num = 2457;
			if (num == 2)
				num = 2460;
			if (num == 4)
				return ("リース達がナルヴィアを後にしたその頃‥大陸東部では王都バレムタイン脱出ファサ軍率いて帝帰還目指国暦６２０年月六万とゼロるマ三ザドッツ平野激突戦わずか３時間側圧倒的勝利終こ壊滅皇子逃亡中下よっ殺" +
				"害されあ一方、制教対副官クトゥ竜騎士団急襲民衆ら共囚穏健派神解放ウヌ殿行くますヶぶり歓喜も迎え入内乱結キ砦シェ女妃密やな会合持本調印両休・友好条約骨定めラズベ５息人々う日宰相地位就き幼補佐役将" +
				"事託単身北辺境へ旅立自存在新火種恐同盟諸侯強要望公爵継承第代載冠式続婚礼各多数詰掛け久賑見せ巫ボ司長工夫妻ミオニ並びどギ祝福和到来宴手差伸べ先セ服包んだ若彼寄添可憐弾ば笑顔デ著記\u3000１７４章").ToCharArray ();
			if (num == 6)
				return ("王国暦６１９年、秋バルモア地方に生まれた民衆解放軍＜自由ヴェリ＞はそを率いるセレニの乙女圧倒的なカスマ性と団運用巧さが相ってわずか数ヶ月間諸都市シノンディナ南部す至こ帝失将兵二万余も及びラーズ" +
					"中長引く遠征不満漏ら者現始め寝返り総督ピ伯爵状況狼狽し事態打開道探公ザツハイムで‥頃本拠館同じタ司令官ファサ皇子苛立ち募せ").ToCharArray ();
			if (num == 11)
				return ("王国暦６１９年、春四部同盟を率いて目覚まし活躍見せたディアナ公爵ベルードは海に浮かぶ孤島流刑の身となっさら追打ちけるようセレニ軍前帝が誇名将＜竜騎士ゼフロス＞現れ諸侯急襲始めも一人声支えバント" +
					"奮闘わず徐々瓦解兆こ都ザツヘイムで‥方東本拠地リオタヴェ占領す宮総司令官ァサ皇子日快楽溺面ラ州展開再び増強重要点ほんど奪ズク最後砦あマゲ塞守内立隊収容").ToCharArray ();
			if (num == 13) {
				if (name == "mission.ar")
					num = 2261;
				if (name == "evitem.ar")
					num = 2449;
			}
			if (num == 14) {
				if (name == "sysfont.ar")
					num = 549;
				if (name == "namene.ar")
					num = 552;
				if (name == "helpmsgb.ar")
					return ("次ページ前ヘルプモド閉じるロフィ表示人間関係詳細カソ移動終了両親・兄弟に変更家族恋友主君敵対項目順序編集（暫定）選択解除ユニットへャン戦術マ戻スキ現在ので並べ替え文字入力／メュセして左右１削種" +
					"別切りますか？ショ再生ォ停止開出撃もど番れアイテム操作コ実行反側を送非押ながら方向上下類中と交換廃棄取得、設画面位置調整時み始グ初期一").ToCharArray ();
			}
			if (num == 549)  //same as 14.sysfont
				return ("ロードハイアポステル槍兵騎帝国農民王士東方剣ボウナトランガオパディュクブッジェネゴ斧装甲ギ弓石重狙撃工補給マセリダバタ渡り戦聖ォシフグ頭目山賊海馬盗サビ修道プ司祭僧ャズ神官教暗黒雪砂族公爵悪党" +
					"ァノピレヤ詩人崩れ建造物ム一般市男性少年中老女貴村配若い秘書店主（やせ）太おかみさんじ紳系奥青姉妃ホメ船乗巫伯長錬金術宮廷ヴコゼカソペエ短予備壊たョミツキ軍用正式旧妖刀殺ベチニヒ大ザ房試昨への" +
					"破盾熱氷河雷雲つるはし粉砕ワ手速射三連魔ヌ弩軽ど２３４炎ゥ１５６７８９Ⅱケ光丸風闇＋上級Ｓ形火烈輝ＭＬ将邪木矢銅鉄鋼致命眠毒貫き新型精度腕輪俊敏守力祈護符奇跡癒流星月陽巨天白虎鳳凰煉獄無双指竜" +
					"鱗飛ⅠⅢ財宝扉筋薬体消携帯袋気付け鎮静剤貨銀水晶草束集編帽子尻が小箱婦肖像画帰還失額飾橋設計図整引竪琴普通元な丈夫頑強駿モ死だら灼板素材眼皮ゲ隕曜ユ塵羽糸古代呪液琥珀捕獲仔食料にえ虜玉座間鍵牢" +
					"闘自動生成名０城門壁部Ｐ捨て置場\u3000脱走Ｘ森第四団同盟空巣ゾ増援隊伝令境送輸戒警義勇支ヨ衛包囲傭砦街二ぎ験処刑駐留信者十父母防揮五六巡礼救赤兄弟偵察狩猟住看七収容所徳逃亡側近御柵本営資倉庫舎監視" +
					"徒突哨翼吏買鍛冶屋員雑娘未定婆供入西合行商従こ説明係開始案内墓客使憲仮面酒酔っぱ諜番平地荒林密麓岳川浅瀬／湖洞窟旗都落跳階段殿床回復垣崖家灯台館塔会宿原沼茂院特殊歩別齢歳職業出身Ｃｏｓｔ？妻妹" +
					"前不能産量在数武具拠点規ＨＷｐ税全そ他表示切替すべ要助以外あ移範ち止位調ＢＧＥ標準高最初期ＯＮＦ攻操振機選択低時簡易比較順序告経路勢識敵効果Ｒ下継続待確認情報終了両親・恋と友君対種類価格足完品" +
					"状況器雇掛絨毯磁花瓶鳥【活】彫希望豪華現持残有覧う売預却耐久受賞首蝉亭仕利貸副侍学検索並理功率依頼：任務を見章まで制難−ヘ師販属練提条件求請払ＹＡＤ差込口更決戻断記録損登執室［］心傷多今も！取" +
					"挑発威嚇降伏態奪わ応急覚めｉｆｅ何離姿げ交換く唱避睡混乱被反減耗法加「」幸運得値技昇事錠、再後先程隠熟％相怒分ひ結界味舞様早倒干封む周必次進距泳ぐ探隣接投擲的変健虚弱愛徐々ご略篭解除居。但潜‥" +
					"疾限改宗詠等追迷彩．倍夜襲ず当半己算乙衰峰打可抜＃＄＆専保存ＩＪＫＱＴＵＶＺａｂｃｄｇｈｊｋｌｍｎｑｒｕｖｗｘｙｚぁぃぅぇぉざぜぞぢづぬねばぴびふぶぷぺほぼぽゃゅゆょよろゎゐゑヂヅヮヰヱヲヵヶ" +
					"私管机八九由討伐撤退線梁血谷沈黙英雄…達非鉱霧願実訓壇逆珠割幽霊誇労働島夢弾泥棒治固過忘意紙謎絆遠亜麻訪問站基異燃贈約悩廃誘拐真魅惑香旅永嘆瞳漢模擬汚放疑偽世争尋寡孤語春滅背立責叙勲声証稼彼潮" +
					"共裏償日純休負好苦戸締注粗牛羊野兎蜂蜜煮鶏茸焼羅貝柱魚蒸季苺盛卵菜布涙象牙鏡文紋芝衣縛網髮荷繁港郊区議広衆堂典劇占節牧園紹介埠謁丘庭邸宅演習南").ToCharArray ();
			if (num == 552)  //same as 14.namene
				return ("剣闘士自動生成名１２３４５６７８９０城門壁扉予備リースウォドエルバトマセアデレオンシロックイ一部サダズパラミティェファペヴネギナゼニメグザＰム捨てる携帯袋置き場軍用馬ジベチブ神官長\u3000" +
				"タハャ兵脱走プＸガ山賊森の民ピ帝国第四団ゴ盗同盟ボカ空巣ソ旧ノツ海ゾキケゥホユコヘュゲ市公爵夫人司祭村増援隊伝令工モ境守騎輸送警戒義勇支ヨワ護衛包囲狙撃傭砦街道二三暗黒かせぎヤ竜弓試験ヌビヒ" +
				"処刑ポ駐留信者十父母防指揮五六氷新補給砂族火巡礼救赤い兄弟偵察狩猟住飛看七捕虜収容所悪徳（逃亡中）側近御柵本営資財倉庫槍舎斧監視がり徒突強射手哨翼吏買僧ョ鍛冶屋店員雑貨娘男王子未設定老婆少女" +
				"供入西連合将伯行商宮廷従木こ仔説明係開始案内墓客使憲船仮面酒酔っぱら間諜婦番戦短壊れた正式妖刀殺大房作破盾熱河雷雲つはし粉砕速魔聖石弩軽重ど炎Ⅱ光丸風闇＋上級Ｓ方形烈輝ＭＬ邪矢青銅鉄鋼致" +
				"命眠毒貫型精度腕輪俊敏力祈符奇跡癒流星月太陽巨天教白虎鳳凰煉獄無双鱗ⅠⅢ宝筋秘薬さ体消気付け鎮静剤金銀水晶草束詩集編み帽尻小箱肖像画帰還失額飾橋計図整引書竪琴や普通元な丈頑駿死んだ灼板素" +
				"材眼皮隕曜塵羽糸古代呪液琥珀獲食料にえ玉座鍵牢平地荒林密麓岳川浅瀬／湖洞窟旗都落跳階段殿床回復垣崖家灯台館塔会宿雪原沼茂修院特殊歩般性別年齢歳職業出身Ｃｏｓｔ物？妻姉妹前不能産量在数武具拠" +
				"点規ＨＷｐ税全術そ他表示切替すべ要助以外あ移範ち止位調ＢＧＥ標準高最初期ＯＮＦ攻操振機選択低時簡易比較順序告経路勢識敵効果Ｒ下継続待確認情報終了両親・恋と友主君対種類価格足完品状況器雇掛絨" +
				"毯磁花瓶鳥【活】彫希望豪華現持残有渡覧う売預却耐久受賞首蝉亭お仕錬利貸副侍学検索並理功率依頼：任務を見章まで制難−へ師販属貴練提条件求請払ＹＡＤ差込口更決戻断記録損登執室［］心配傷多今も！" +
				"取挑発威嚇降伏態奪わ応急目覚めｉｆｅ何離姿げ乗交換く唱避睡混乱被反減耗法加「」幸運得値技昇事錠、再後先程隠熟％相怒分ひ結界味舞様早倒若干封じむ装巫周必次建進距泳ぐ探隣接投擲的変健虚弱愛徐々" +
				"ご略篭解除居。但潜‥疾限改宗詠等追迷彩．倍夜襲ず当半己算乙衰峰打可抜＃＄＆専保存ＩＪＫＱＴＵＶＺａｂｃｄｇｈｊｋｌｍｎｑｒｕｖｗｘｙｚぁぃぅぇぉざぜぞぢづぬねばびぴふぶぷぺほぼぽゃゅゆょよ" +
				"ろゎゐゑヂヅヮヰヱヲヵヶ").ToCharArray ();
			//		if (num == 2256) {
			//		if (num == 2257) {
			if (num == 2261)  //same as 13.mission
				return ("戦う理由\u3000シノン公国より同盟軍の本城ナルヴィアへ入を果たそとする、リース率い騎士団は砦近郊にあサラ村到着し。こで追放されェ兵が無法な振舞行って司祭依頼受け火ぶ切落山賊討伐待王ウォケ" +
					"側ち冷遇下脅かニム命じら帰還遅ば逃亡見過酷条件突きつ刻限夜明ま絶望的状況始三人神殿ボ教名高位巫女「」迎えく護衛欲隣デミ森盗住み周囲治安悪化だ撤退援ハイド都ュヘ陥敗走将達帝撃遭何も助ロズオク願" +
					"出決意残通ゴ原ず没危険地帯防然裏相対バ堅牢持ザろせ民殺守生死ゆね前線街レブ救申エ共市母親期日暮四方包網め困難作開子タ父不興買配ツ南幽閉反乱組織屈強擁攻ぐ打向進木馬竜ゼフ諸侯急襲崩壊兆窮度合増" +
					"マゲ要塞北カネ孤立部隊請橋梁破備投降手渡お失わ補充工解河止聖問題発指揮言正面門提流血谷修復侵妨害排除べ精鋭ベダ渓越背後足快速闇首メ奪目伏大探索宮廷キ呪駆使勝利沈黙セ乙休一ト令々迫来力差食集者" +
					"ッ逆汚事断単身抜再会彼励結束己声少英雄伝説多数官囚最終幕上略宝剣…荒貴重物ょ？（）料調徘徊材んど品店取全信ゃ！非道兄弟居座尽グ鉱霧若川水毒混供被源家武器屋情娘ペテ師騙連戻コ形＜プ＞実訓練新兼" +
					"半ほ距離駐留給気壇沼異徒焼建設中犠牲‥海ジ島査職房巣誘拐錬金術勇騒船商機能古珠ガ砂漠代跡消息捜む雪割花霊や狙び君誇酔様引老げづ制労働所刑私監獄送届脱得ぬ夢３０年体孫ァ仔必野性捕試傭ギ弾狩虜縛" +
					"４泥棒党返思妻青晶輪倒極賞薬草病療斧熱氷雷雲詩紛盾具製旧式丸個族心徴頑固避矢尻忘自宅置編帽傷回素婚贈注文髪飾夫石ョ暗黒魔ヒ致伯肖像画悔紙謎小荷採絆否知恋任務遠友亜麻携袋布男訪収容胞次月晩移添" +
					"ピ導験詳担当技聞ポ派遣ご恥噂站基型圧猟東湖象牙鏡味疫特効貰槍秘密員報敵パ潜接記書光僧義従猶予炎燃婆亭主墓掃計図約モ両２悩付廃ユ在庫真嫌魅惑香旅芝衣装永久祈ひ嘆瞳昔七財灯漢模擬疑偽別世界争癒尋" +
					"寡語眠二春愛滅１責館求叙勲証陽境Ⅱ稼ぎ場潮風償怒純姉妹蝉告ぇ負好苦戸締ぞ糸粗闘動成５６７８９壁扉Ｐ捨用チ長ャＸ第空ソゾゥホ爵輸警戒支ヨワヤ弓ヌビ処十五六巡礼赤偵察飛看徳御柵営資倉舎視射哨翼吏" +
					"鍛冶雑貨未定西係案内客憲仮酒ぱ間諜婦番繁華港外区執室議広衆堂：級典劇占季節造剤学牧農園林院仕紹介保管埠頭謁丘庭邸ＱＭＡ演習路項細ⅠⅢⅣⅤⅥⅦⅧⅨⅩ易種章選択功ＥＤＣＢＳ").ToCharArray ();
			if (num == 2263)
				return "攻略のヒント\u3000「ラーズ祭壇」フェイ、ァミアが死亡しない様注意てゾヴィを撃破下さ。ダクオブジにつは教建物で周囲３ヘスま敵ユニッ命中および回避それぞ＋１５％すと戦うこ不利離かある壊上策".ToCharArray ();
			if (num == 2264)
				return "攻略のヒント\u3000「実戦訓練」こマップには跳ね橋が設置されています。を使うかどで変わりつ操作るとよっ開通や遮断き近くため建物（番小屋）ず行陽合そ所しょ".ToCharArray ();
			if (num == 2265)
				return ("攻略のヒント\u3000「若き騎士たち」アーサ、ルヴィと共に敵リダを倒す撃破マップで。索ついて夜や洞窟砂嵐などは視界が制限されま目特殊スキ持っユニ周囲３ヘク距離しか見るこせん（通常）味方仲間う一人も対象" +
				"え状態あば全員そり条件同様戦闘不能睡眠１").ToCharArray ();
			if (num == 2266)
				return "攻略のヒント\u3000「下街英雄」長射程暗黒魔法についてラーズ教団使用する中は、ブックメティオやバウシュようなを持もが存在しま。精神力低ユニ撃受けと致命傷りかねせんで注意必要（ただずＨＰ１残）".ToCharArray ();
			if (num == 2267)
				return "攻略のヒント\u3000「王女と傭兵」城門についてこマップ内あるは開錠スキルを持ユニでけが出来ます。た、含む耐久値設定され建造物撃破壊可能ＨＰ０なりき".ToCharArray ();
			if (num == 2268)
				return ("攻略のヒントⅣ章「撤退援護」ＮＰＣが撃されない様に守りらをします。マップター制限つてこ勝利条件はユニ追くる敵部隊や、山賊かっできだけ多せたち自軍もとう設よ場合定め完了取残捕虜主人公あリス副官ウ" +
				"ォドずゲムオバ上状態全員離脱交換縛特兵種（後述）ナルヴィア送月先報告コ資金得支払額減対象傭ん騎士神貴族ど正規例帝国ゴラ盗団メュ表選択所★ク確そイベ発生\u3000身代戻執務室帰戦闘不能お出動的回復武器ギ" +
				"パ殊魔法ブ進むＭ少手入大切使用ょ").ToCharArray ();
			if (num == 2269)
				return ("攻略のヒント\u3000「スコーピオ」同盟軍を護衛しながら敵撃破てください試作につバリタ兵装備るはお互隣接すことで命中率致上昇効果ありま。れ、ユニッ数比例壊た外消滅もう一大き特徴時キル先制射付加").ToCharArray ();
			if (num == 2270)
				("攻略のヒントⅩⅤ章「英雄伝説」\u3000特殊扉についてマップ内点在するは、鍵やスキル開錠を所持しればくことが可能で。か一部なっおり通常手段きません（赤牢）物語進行よリー隣接イベ用見え屋エア目隠さ覗状態" +
				"そら方的撃受け非不利解除城壁床全ユニ入地形騎馬飛下コド等降必要あ").ToCharArray ();
			if (num == 2271)
				return "攻略のヒント\u3000「異教神」長射程暗黒魔法についてラーズ団使用する中は、ブックメティオやバウシュようなを持もが存在しま。精力低ユニ撃受けと致命傷りかねせんで注意必要".ToCharArray ();
			if (num == 2272)
				return "攻略のヒントⅨ章「橋梁破壊」\u3000跳ねについては操作することよっ開通や遮断ができま。近くをため建物（番小屋）設置されず行場合そ所しょう".ToCharArray ();
			if (num == 2273)
				return "攻略のヒントⅦ章「公子救出」　城門についてこマップ内あるは開錠スキルを持ユニでけとが来ます。た、含む耐久値設定され建造物撃破壊可能ＨＰ０なりき".ToCharArray ();
			if (num == 2274)
				return ("攻略のヒントⅤ章「城砦防衛」特定ター数拠点をするマップで。バリスについては３～７射程遠距離武器一度移動き短も、そ威力他凌駕しまただ角があり全方位撃わけせん死とな向へ行う回頭必要最小ふころ飛び込" +
				"れべ隙１２詰め気破壊っ戦法対有効").ToCharArray ();
			//		if (num == 2275)
			//		if (num == 2276)
			//		if (num == 2277)
			//		if (num == 2278)
			if (num == 2279)
				return "攻略のヒント（１）２３４５６７８９０／続きを読む".ToCharArray ();
			if (num == 2284)
				return ("仔牛のソテー柔らかい肉をさっと焼き、赤ワインスで仕上げた一品。川蝉亭人気料理つロトビフじくり時間けてはもちろん立どうぞシチュぷ各種野菜ふだに使定番味おみ保証付カモ鴨こが血香ばし食欲そます羊リヌ" +
				"ガックやオニな陶器詰め込固伶製兎蜂蜜加え芳醇後引女性大レジ煮ょセあるウサギ爽デャミ挽卵ル調ドブ若鶏ム乳小麦粉作心温ホ寒季節代名詞給アナ好物キ軽丸外パ中鳥茸ヴィ産ピポ豚甘辛添メヤ草特有豊比較的安" +
				"価近所評判骨べれマ呼タ腹膨甲羅蟹ほぐ単純素材出エハプ感せ貝柱白ラベ身皮下脂倍増バ隠ネ火通ノコ前胃魚風淡泊蒸注文多商海幸栄養満点！厚切美爪ご２本〜口？ゲ衣山ダ緑黄色盛合わ四朴家庭ズ地方採子様薫具" +
				"良へよボヨ薄木入低包苺酸ぱぺ黒ョ炒…ケツ神言伝杯表ひグ更別「び」ゆ半熟客要望応ォ酒").ToCharArray ();
			if (num == 2449)  // same as 13.evitem
				return ("携帯袋の束商人マルクス品。いくつもをねてひとりにした剣壁掛け紋章儀礼用め、実戦使するこはできな大絨毯稀少虎皮あらっ高級非常価白磁器花瓶透通ようナヴィアシカ製捕獲が難されンテロプ盾置物際" +
					"じゅん私室入口敷ノ織逸リー故郷懐かむコッファ事収納お家具時折前持ち主ま忘出タペト豪華鳥躍動感目粒宝石名画【復活】破壊再生モチ描有絵今亡悲運天才ミレ作乙女彫像美気分落着良香箱財そだ中身ぽ調" +
					"べみ‥希望一性肖見心語ベド素材職腕駆休疲癒？青水晶指輪込店セバ妻形ジュ草薬解熱料詩集神々関記述始酒場会男切秘地図ネパ海賊王伝説・手編帽子誕日姉贈温雪割永久凍土え続命力や冷雷矢尻必要光宿ボ" +
					"小ブ街撤退単騎猛烈追撃来士婦ラズ若毒特殊合紙へ宛謎包言預弓屋原木村森伐採ニ麻布産サウ仕修道院ザ防衛任務就恋添暗殺計書ェ涙古び装備二式託デ東息珍毛重象牙鏡ろ闘技ケ対（１）送回２３４５６７８" +
					"情報文帝国軍潜せ兵受取グ頼疫病効無ば犠牲者増鉱山夫ゴ掘ＨＢ設精密廃ユ造残骸背面貴族現在未竪琴弦本芝居衣旅座ガ駿馬方教玉間鍵扉開牢獄聖司祭深傷縛網発隠メ真珠川髪飾孫娘結婚注オ戻所絶的御与わ" +
					"荷ム愛詳細表示").ToCharArray ();
			//		if (num == 2455)
			//		if (num == 2456)
			if (num == 2457)
				return ("かくしてはただ一人でナルヴィア城を後にのあるそ頃、彼が目的とすダムサ砦‥翌朝馬交換めーラ村立ち寄っこ待受けいもバストン街編成終えシノ騎士達帝国守備レマゲ要塞到着橋通過望まぬ戦覚悟不思議な同盟軍" +
				"族高掲げられ・ボニ３隊排除路北指行手司教ゴドァピ伯爵篭難攻落都市リウォ初団迎今おミオェタ両公子合流").ToCharArray ();
			//		if (num == 2458)
			//		if (num == 2459)
			if (num == 2460)
				return ("王国暦６１年４月境の要衝サキリア塞は帝大軍によって包囲されたヴェモルディス世を救援すべく八万兵従えイシ森南下しが若き名将ゼフロ奇襲り戦死同盟そ後続敗走で十余失第３２代五だベウックラーズ脅威対抗" +
				"るめ結成西部事あ全指揮主委ねらいな動揺も線各地崩壊一経ず都バレムタン迫勢見せ嫡子ォケ新体制建直図東方かァ皇本隊と北来別働諸分断陥落阻止得ぬ状況重臣ち擁ナ公逃宮殿仮定侯共うへ参集命令発ガ草原位置" +
					"小ノト爵配百騎率路目８日入城前立寄村こ（物語）‥始ま・").ToCharArray ();
			if (num == 2462)
				return "一回戦聖騎士ルヴィＶＳテンスベガー\u3000対ニドチェ決勝自由バジ".ToCharArray ();
			else
				return ("？あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽっゃゅょぁぃぅぇぉアイウ" +
				"エオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポッャュョァィゥェォヴゎヮ０１２３４５６７８９ＡＢＣＤＥＦＧＨＩ" +
				"ＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺー！？、。「」Σ´Д｀∀ヾ゜дω・㌔㌧㌦㌍㌢ゝ秒ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ冬燦峰【】\u3000西我々眠見捨地人間私最後力大陸役立思許様他" +
				"干渉不幸招旅裏切神竜王類次時代委定族同士長苦戦現状正使限誰管理恐未来無関係墓暴解放玉永劫守仰一与彼支配者意志約束…争考少違本質的好認飽欲望進化鍵運命死言生物殺食動作弱肉強新世界摂甘自然愛草木重野獣性温" +
				"心信導目覚結果出残捧民救術教危機迫念資格仲知問題男狂気悪北沼封印責任待会談終日事託受証拠聖賜芳女何申破滅勇剣授手伝壁絵右光魔道書左宝黄金輝甲冑身暗黒向説今前御僕協話聞助願邪帝国侵略背度訳虐分悔騎誇味悟" +
				"上子軍内弟伯爵通以組敵方専門判断流水元十承行汝加護失探継描姿遣奇跡下団傍有由誉傭用要踊覧率轄屯侶了領剰輪麗歴偉録綺東友奉武至高是非卿勧礼先娘嘆兵多攻込座亡努務数年名参隊取避得決臆病熟詔婦預昨姪塞隣親派" +
				"公二乱始半市太優勢追詰求策注甦宿復活阻止老師実初典記恋悲落涙晶再遺存反崖静殿耐援到着余送簡共音沙括篭城続顔態打開安姫葉故唇奪笑南外布陣程規疲弊中募義訓練届集奴入報告所属明確馬鹿猛潔諸相困戻必変郷妃在抱" +
				"山賊征陛挙急宰保対持謝父海畑起恥侯遠場骸深負噂鵜呑絶罠論妥当早治回各防衛尽腰降期忠層働席主家冒涜議足近満片付口久修休喜頼直都合床伏歳政応逃快迎拶殊勝候恩揺留暮荒恨難差伸小頭皆侮痛末挨島貴暇忙嫌伺引煩怯" +
				"君帰達減真似騒面倒昔際姐俺張忘郎透丈夫連適緒耳健村警嘘赤興賭慢己体緊感欠律敢肩並売災冗去準備獲飛巡枚雇棒文句屁第割仕墜狩盗辺横襲撃住寄愚痴黙若祈統制群過利読基将荷担険炎形誓夢白想振叶福台詞慰縁貰血祭汰" +
				"怪昼闘答案散歩冷憎消価値建築朝夕閣令従陥突訪段平皇器万敗成就造短別特窟圧盾焦采牢構囚稼忍踏捕可店兄漢胸呼閉怖脱全部屋扉借酬払渋商買輸具衆額茶党請企騙筋縄妹風吹根巣奥洞覆雲延魂慌腕増隷母紙姉乞離寂返番街" +
				"旗厳隠祖旦港息官巫石像札幼町巻馳居計遅宮偽頃貸酒溜歌指単迷晴喫情寛広完河柄労密戒裕渡充呪誤異四採（）収益靴泉泣濡拾赦浅恵乗誘拐謀討伐駒只聡誠慕評処遇斎客線千謳斐例件搬傷婚甥位臣狐退叔患露筒抜置鉄脚哀容" +
				"弾課贄拷刑闇吟遊詩呵／序章整及砦隙狙弁疑衣悠独杖予堅嗚威和腹震箱抵歓麻占犬刻惨抗品逸囲秘薬飲糸火射観怒良頑英雄繰罪史古移経腐階級沿岸点臨操月寝洗熱屈牧川泳溺惑天原営室字学礎田舎憶夜斥装妙業鎧揮精鋭首香" +
				"豚尻叩速走発畜燃途端毒焼朗被害臭慎標歯車刃為糧讐癒虫捜索湾越肥沃域擁敷帯版図搾貧憤権鎮粛清希包影百裔済契服陰積飢肝漁穫杯揃鷹牙睨押接損敬徳勘玄常謎料刀儡傀汚掘亀砲技極縛稽油駄詮供鼻触灸検虎叱監視驚痩弓" +
				"声孫廃矢悼給笛橋副幾撤側美拭船互潮壊脅訴易把握辛晩惜鎖跳窮崩掌随杞憂詳寒唱裂掠土揉境素皮厚比懐柔孤妻逆銀革紛森拓唯善乏司総潜花賞条檻虜嘲楽斬吐燻交絞吊弄費蹄棄周逝諦鳥養才能躍戮逗換調朽呟倉犠牲固鍛殻餞" +
				"狭毎埋折厄介表勲貨執赴酷狡猾税法蔵慣芸量泡紹泊滞納幽巧祥吸局因曲軽蔑貫蓄細工酔盟秩蜂僧猊嬢亭個卑劣遭育空角捉潰還蹴駆奸智購殲衝叡眼激瞬誕凄瞳拍慮咲庫波蘇葬湧召喚匹胃農選獄膨覇墟林狼択編画替示設範展停烏" +
				"穏齢這凶僻蛇療隔施慈青習冶砂丘等徒飼豊谷逐普尊員徴複雑傾扱懸勉羽匂傲穴朴仁斉栄験輩兼材骨双斧富即鮮ヶ賢芽節辞穢侍種堕蹂卵網列浄称粗低衰符試粉嬉攫挑財館控砕針米曇製康嫡障顧戯拒否如虚嫁腑紅染三唸販喉汁提" +
				"督稀遂灯況猶昏尋褒裁剥胆犯除袋浮里屠紋艦獅凡躾匿弔漠偵察倍軟禁貶児苛職庇拉致涯飾槍詫遥識岩旧后星髪冥祝駐功併両洲距弩挟超伍猟掛路抑拝混浪巨薄幻肌暑妾毛乳産痕忌迂却愉檄翼携般釈浴凌勤症厩巷雷講模投耗環勅" +
				"仇殴尚坊五算添醒托漆暖含舞遮沸号灰式秋儀恒歪社枢畏冴躙喧嘩貯仔殖貌献牛象魚那憧銘演沈語岬頂戴懲飯珍頻繁映煮埒悩盛織慨脈省埃傘八州隅筆妬峠嵐秀憐償錆辱汗謹系緯屍沢仮欺順絡愕濃徐脳績銅緑更底岳匠鳴罰七羊脂" +
				"婿賎励景央署壇繋緩宣睦恰隻締色豆寿縮蓮棲蛮氏賛効塔掃概唄勾寸鋒泥廷錯転叫微曽醜煉妨偶掟兆壮午凱儲痣槌烈疾徹俊敏瀕拡庶湖刺渾刹粋贅崇唐惚餓沖没怠看板鏡魅霧鬼璧劇凛培蒙昧藉悶蠢怨霊瘴蚊棺桶華雫雨逞禄抹寧贈" +
				"脹羨撒○×△□鋼登＋餌飴釣鞭姑楯科諌翻擬簒迅掲瀬堂俗゛舌噛侭頬磨摘祟隼照酌～肖遍猫楚眉盲免雪翌帳茨膚競嬌丸爛漫畔宗院博冠姻純渇鈴癖凧丁浸貢賀豪罵宴鈍乙陽昇芯便戸源幕禍排促滴創郊玩堵宅房改些澄航摯－喪Ⅰ" +
				"ⅡⅢⅣⅤⅥⅦⅧⅨⅩ諾僅補ゐゑヰヱヵ熊喋錠鼓架※＊既電♪削蒼氷嗜卓渓咄嗟＃＄＆湿阿呆枠此惹幹拘．催擲依暦粒栗較韋睡揚詠疫蔓区彷徨遙砥銑矛診尾蝉煽駿♂♀爪拳茂池六麓，：；¨＾￣＿―‐＼∥｜‥‘’“”〔〕［］" +
				"｛｝〈〉《》『』±÷＝≠＜＞≦≧％§☆★●◎◇◆■▲▽▼→←↑↓ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψ垣九岐寵球研樹蒸壺弦謁校賓園剤燕叙週＠＠辿維胎" +
				"瓦篤旨盆栽麦響脆箇項暫痺汎型竿壷噴凍蛾鱗耕亜鉛鉱錬隕譲頓憩醇克蕩沌馴虔徘徊宛査井汲碑貿綻推奨郭套灼載堪梁披幅贔屓嶺穀菜袈裟挽晒秤殉斃儚彫菩尖碧酵弐衡融疎哨薔薇縫陶鴨蟹淡酸爽薫庭炒蓋鶏兎茸羅貝柱苺季蜜塊鳳" +
				"凰髭硬粘幣溶橙屑牡猪鳩煎植鯨靱塵曜銛棍但妖嚇円盤捻銭淵煙妄胡述婆坑柵帆枯伴撹据眩濯慧臓雰奏桟医奮竹獰颯傑漏則塗珠蟲府吉趣廠洩諜捲聴罷袖循棚吏紳机絨毯磁瓶懺贖燈邸胞彩液琥珀享啓伊綴貼逢穿孔豹佐鉱帽絆膏扮潤" +
				"咳竪琴祓訛筈咬綿賦乾喘宜峙譜溢憬債童芝嫉拗矜囁垢雅苗篇猜毅囮陪卒暁扇站蒐絹蚤奔眺賃樽詣掴審懇畳藁膠測牽憑蹟逮楔巾涼薦械霞串漂塩頁瞭詐碍奢籍雛晰拵藪鞍牝僚究冊媚賑虹恭蒔鋤搭憲刈裾捌蝕鞘倹泰爺兜呈＠＠＠＠＠" +
				"＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠" +
				"＠＠＠＠＠＠＠＠＠").ToCharArray ();
		} else {
			if (num == 0)
				return ("王国暦６１９年２月帝都レオグラードは人々その狂信的な政治体制に恐れおいてた東部三を手中収めゼフロス将軍幼マナリ擁しサキア要塞陣構え配下万兵らび彼幕う多く民訴こ対ァイルバムタン守り二残自六率目指" +
					"ベ子る由ヴェ総勢ユト・ハ方面か伺あィボニシノ一地圧帰城途上っ、立ち寄村でテ驚べき情報がもさ教皇ウヌズ団支脱出妃とす助け求仰ぐ草新派心旧間激抗争始ま３奪回進窺").ToCharArray ();
			if (num == 1)
				num = 2457;
			if (num == 2)
				num = 2460;
			if (num == 4)
				return ("リース達がナルヴィアを後にしたその頃‥大陸東部では王都バレムタイン脱出ファサ軍率いて帝帰還目指国暦６２０年月六万とゼロるマ三ザドッツ平野激突戦わずか３時間側圧倒的勝利終こ壊滅皇子逃亡中下よっ殺" +
					"害されあ一方、制教対副官クトゥ竜騎士団急襲民衆ら共囚穏健派神解放ウヌ殿行くますヶぶり歓喜も迎え入内乱結キ砦シェ女妃密やな会合持本調印両休・友好条約骨定めラズベ５息人々う日宰相地位就き幼補佐役将" +
					"事託単身北辺境へ旅立自存在新火種恐同盟諸侯強要望公爵継承第代載冠式続婚礼各多数詰掛け久賑見せ巫ボ司長工夫妻ミオニ並びどギ祝福和到来宴手差伸べ先セ服包んだ若彼寄添可憐弾ば笑顔デ著記\u3000１７４章").ToCharArray ();
			if (num == 6)
				return ("王国暦６１９年、秋バルモア地方に生まれた民衆解放軍＜自由ヴェリ＞はそを率いるセレニの乙女圧倒的なカスマ性と団運用巧さが相ってわずか数ヶ月間諸都市シノンディナ南部す至こ帝失将兵二万余も及びラーズ" +
					"中長引く遠征不満漏ら者現始め寝返り総督ピ伯爵状況狼狽し事態打開道探公ザツハイムで‥頃本拠館同じタ司令官ファサ皇子苛立ち募せ").ToCharArray ();
			if (num == 11)
				return ("王国暦６１９年、春四部同盟を率いて目覚まし活躍見せたディアナ公爵ベルードは海に浮かぶ孤島流刑の身となっさら追打ちけるようセレニ軍前帝が誇名将＜竜騎士ゼフロス＞現れ諸侯急襲始めも一人声支えバント" +
					"奮闘わず徐々瓦解兆こ都ザツヘイムで‥方東本拠地リオタヴェ占領す宮総司令官ァサ皇子日快楽溺面ラ州展開再び増強重要点ほんど奪ズク最後砦あマゲ塞守内立隊収容").ToCharArray ();
			if (num == 13) {
				if (name == "mission.ar")
					num = 2261;
				if (name == "evitem.ar")
					num = 2449;
				if (name == "areanml.ar")
					return "ABCD\u3000EFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]".ToCharArray ();
			}
			if (num == 14) {
				if (name == "sysfont.ar")
					num = 549;
			}
			if (num == 549)  //same as 14.sysfont
				return ("ロードハイアポステル槍兵騎帝国農民王士東方剣ボウナトランガオパディュクブッジェネゴ斧装甲ギ弓石重狙撃工補給マセリダバタ渡り戦聖ォシフグ頭目山賊海馬盗サビ修道プ司祭僧ャズ神官教暗黒雪砂族公爵悪党" +
					"ァノピレヤ詩人崩れ建造物ム一般市男性少年中老女貴村配若い秘書店主（やせ）太おかみさんじ紳系奥青姉妃ホメ船乗巫伯長錬金術宮廷ヴコゼカソペエ短予備壊たョミツキ軍用正式旧妖刀殺ベチニヒ大ザ房試昨への" +
					"破盾熱氷河雷雲つるはし粉砕ワ手速射三連魔ヌ弩軽ど２３４炎ゥ１５６７８９Ⅱケ光丸風闇＋上級Ｓ形火烈輝ＭＬ将邪木矢銅鉄鋼致命眠毒貫き新型精度腕輪俊敏守力祈護符奇跡癒流星月陽巨天白虎鳳凰煉獄無双指竜" +
					"鱗飛ⅠⅢ財宝扉筋薬体消携帯袋気付け鎮静剤貨銀水晶草束集編帽子尻が小箱婦肖像画帰還失額飾橋設計図整引竪琴普通元な丈夫頑強駿モ死だら灼板素材眼皮ゲ隕曜ユ塵羽糸古代呪液琥珀捕獲仔食料にえ虜玉座間鍵牢" +
					"闘自動生成名０城門壁部Ｐ捨て置場\u3000脱走Ｘ森第四団同盟空巣ゾ増援隊伝令境送輸戒警義勇支ヨ衛包囲傭砦街二ぎ験処刑駐留信者十父母防揮五六巡礼救赤兄弟偵察狩猟住看七収容所徳逃亡側近御柵本営資倉庫舎監視" +
					"徒突哨翼吏買鍛冶屋員雑娘未定婆供入西合行商従こ説明係開始案内墓客使憲仮面酒酔っぱ諜番平地荒林密麓岳川浅瀬／湖洞窟旗都落跳階段殿床回復垣崖家灯台館塔会宿原沼茂院特殊歩別齢歳職業出身Ｃｏｓｔ？妻妹" +
					"前不能産量在数武具拠点規ＨＷｐ税全そ他表示切替すべ要助以外あ移範ち止位調ＢＧＥ標準高最初期ＯＮＦ攻操振機選択低時簡易比較順序告経路勢識敵効果Ｒ下継続待確認情報終了両親・恋と友君対種類価格足完品" +
					"状況器雇掛絨毯磁花瓶鳥【活】彫希望豪華現持残有覧う売預却耐久受賞首蝉亭仕利貸副侍学検索並理功率依頼：任務を見章まで制難−ヘ師販属練提条件求請払ＹＡＤ差込口更決戻断記録損登執室［］心傷多今も！取" +
					"挑発威嚇降伏態奪わ応急覚めｉｆｅ何離姿げ交換く唱避睡混乱被反減耗法加「」幸運得値技昇事錠、再後先程隠熟％相怒分ひ結界味舞様早倒干封む周必次進距泳ぐ探隣接投擲的変健虚弱愛徐々ご略篭解除居。但潜‥" +
					"疾限改宗詠等追迷彩．倍夜襲ず当半己算乙衰峰打可抜＃＄＆専保存ＩＪＫＱＴＵＶＺａｂｃｄｇｈｊｋｌｍｎｑｒｕｖｗｘｙｚぁぃぅぇぉざぜぞぢづぬねばぴびふぶぷぺほぼぽゃゅゆょよろゎゐゑヂヅヮヰヱヲヵヶ" +
					"私管机八九由討伐撤退線梁血谷沈黙英雄…達非鉱霧願実訓壇逆珠割幽霊誇労働島夢弾泥棒治固過忘意紙謎絆遠亜麻訪問站基異燃贈約悩廃誘拐真魅惑香旅永嘆瞳漢模擬汚放疑偽世争尋寡孤語春滅背立責叙勲声証稼彼潮" +
					"共裏償日純休負好苦戸締注粗牛羊野兎蜂蜜煮鶏茸焼羅貝柱魚蒸季苺盛卵菜布涙象牙鏡文紋芝衣縛網髮荷繁港郊区議広衆堂典劇占節牧園紹介埠謁丘庭邸宅演習南").ToCharArray ();
			if (num == 552)  //same as 14.namene
				return ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000用馬ジベチブ神官長\u3000" +
					"タハャ兵脱走プＸガ山賊森の民ピ帝国第四団ゴ盗同盟ボカ空巣ソ旧ノツ海ゾキケゥホユコヘュゲ市公爵夫人司祭村増援隊伝令工モ境守騎輸送警戒義勇支ヨワ護衛包囲狙撃傭砦街道二三暗黒かせぎヤ竜弓試験ヌビヒ" +
					"処刑ポ駐留信者十父母防指揮五六氷新補給砂族火巡礼救赤い兄弟偵察狩猟住飛看七捕虜収容所悪徳（逃亡中）側近御柵本営資財倉庫槍舎斧監視がり徒突強射手哨翼吏買僧ョ鍛冶屋店員雑貨娘男王子未設定老婆少女" +
					"供入西連合将伯行商宮廷従木こ仔説明係開始案内墓客使憲船仮面酒酔っぱら間諜婦番戦短壊れた正式妖刀殺大房作破盾熱河雷雲つはし粉砕速魔聖石弩軽重ど炎Ⅱ光丸風闇＋上級Ｓ方形烈輝ＭＬ邪矢青銅鉄鋼致" +
					"命眠毒貫型精度腕輪俊敏力祈符奇跡癒流星月太陽巨天教白虎鳳凰煉獄無双鱗ⅠⅢ宝筋秘薬さ体消気付け鎮静剤金銀水晶草束詩集編み帽尻小箱肖像画帰還失額飾橋計図整引書竪琴や普通元な丈頑駿死んだ灼板素" +
					"材眼皮隕曜塵羽糸古代呪液琥珀獲食料にえ玉座鍵牢平地荒林密麓岳川浅瀬／湖洞窟旗都落跳階段殿床回復垣崖家灯台館塔会宿雪原沼茂修院特殊歩般性別年齢歳職業出身Ｃｏｓｔ物？妻姉妹前不能産量在数武具拠" +
					"点規ＨＷｐ税全術そ他表示切替すべ要助以外あ移範ち止位調ＢＧＥ標準高最初期ＯＮＦ攻操振機選択低時簡易比較順序告経路勢識敵効果Ｒ下継続待確認情報終了両親・恋と友主君対種類価格足完品状況器雇掛絨" +
					"毯磁花瓶鳥【活】彫希望豪華現持残有渡覧う売預却耐久受賞首蝉亭お仕錬利貸副侍学検索並理功率依頼：任務を見章まで制難−へ師販属貴練提条件求請払ＹＡＤ差込口更決戻断記録損登執室［］心配傷多今も！" +
					"取挑発威嚇降伏態奪わ応急目覚めｉｆｅ何離姿げ乗交換く唱避睡混乱被反減耗法加「」幸運得値技昇事錠、再後先程隠熟％相怒分ひ結界味舞様早倒若干封じむ装巫周必次建進距泳ぐ探隣接投擲的変健虚弱愛徐々" +
					"ご略篭解除居。但潜‥疾限改宗詠等追迷彩．倍夜襲ず当半己算乙衰峰打可抜＃＄＆専保存ＩＪＫＱＴＵＶＺａｂｃｄｇｈｊｋｌｍｎｑｒｕｖｗｘｙｚぁぃぅぇぉざぜぞぢづぬねばびぴふぶぷぺほぼぽゃゅゆょよ" +
					"ろゎゐゑヂヅヮヰヱヲヵヶ").ToCharArray ();
			//		if (num == 2256) {
			//		if (num == 2257) {
			if (num == 2261)  //same as 13.mission
				return "ABCD\u3000EFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]".ToCharArray ();
			if (num == 2263)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000不利離かある壊上策".ToCharArray ();
			if (num == 2264)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,!?:;()-'\"~+/*%[]\u3000しょ".ToCharArray ();
			if (num == 2265)
				return ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000ん（通常）味方仲間う一人も対象" +
					"え状態あば全員そり条件同様戦闘不能睡眠１").ToCharArray ();
			if (num == 2266)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000必要（ただずＨＰ１残）".ToCharArray ();
			if (num == 2267)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0.,!?:;-'\"~+/*%\u3000りき".ToCharArray ();
			if (num == 2268)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅳ".ToCharArray ();
			if (num == 2269)
				return ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000き特徴時キル先制射付加").ToCharArray ();
			if (num == 2270)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000ⅤⅩ".ToCharArray ();
			if (num == 2271)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*\u3000[]".ToCharArray ();
			//		if (num == 2272)
			if (num == 2273)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000".ToCharArray ();
			if (num == 2274)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅴ".ToCharArray ();
			if (num == 2275)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅳ".ToCharArray ();
			if (num == 2276)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅲ".ToCharArray ();
			if (num == 2277)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅱ".ToCharArray ();
			if (num == 2278)
				return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000Ⅰ".ToCharArray ();
			if (num == 2278)
			if (num == 2279)
				return "攻略のヒント（１）２３４５６７８９０／続きを読む".ToCharArray ();
			if (num == 2284)
				return ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]\u3000鴨こが血香ばし食欲そます羊リヌ" +
					"ガックやオニな陶器詰め込固伶製兎蜂蜜加え芳醇後引女性大レジ煮ょセあるウサギ爽デャミ挽卵ル調ドブ若鶏ム乳小麦粉作心温ホ寒季節代名詞給アナ好物キ軽丸外パ中鳥茸ヴィ産ピポ豚甘辛添メヤ草特有豊比較的安" +
					"価近所評判骨べれマ呼タ腹膨甲羅蟹ほぐ単純素材出エハプ感せ貝柱白ラベ身皮下脂倍増バ隠ネ火通ノコ前胃魚風淡泊蒸注文多商海幸栄養満点！厚切美爪ご２本〜口？ゲ衣山ダ緑黄色盛合わ四朴家庭ズ地方採子様薫具" +
					"良へよボヨ薄木入低包苺酸ぱぺ黒ョ炒…ケツ神言伝杯表ひグ更別「び」ゆ半熟客要望応ォ酒").ToCharArray ();
			if (num == 2449)  // same as 13.evitem
				return ("ABCD\u3000EFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.,!?:;()-'\"~+/*%[]難されンテロプ盾置物際" +
					"じゅん私室入口敷ノ織逸リー故郷懐かむコッファ事収納お家具時折前持ち主ま忘出タペト豪華鳥躍動感目粒宝石名画【復活】破壊再生モチ描有絵今亡悲運天才ミレ作乙女彫像美気分落着良香箱財そだ中身ぽ調" +
					"べみ‥希望一性肖見心語ベド素材職腕駆休疲癒？青水晶指輪込店セバ妻形ジュ草薬解熱料詩集神々関記述始酒場会男切秘地図ネパ海賊王伝説・手編帽子誕日姉贈温雪割永久凍土え続命力や冷雷矢尻必要光宿ボ" +
					"小ブ街撤退単騎猛烈追撃来士婦ラズ若毒特殊合紙へ宛謎包言預弓屋原木村森伐採ニ麻布産サウ仕修道院ザ防衛任務就恋添暗殺計書ェ涙古び装備二式託デ東息珍毛重象牙鏡ろ闘技ケ対（１）送回２３４５６７８" +
					"情報文帝国軍潜せ兵受取グ頼疫病効無ば犠牲者増鉱山夫ゴ掘ＨＢ設精密廃ユ造残骸背面貴族現在未竪琴弦本芝居衣旅座ガ駿馬方教玉間鍵扉開牢獄聖司祭深傷縛網発隠メ真珠川髪飾孫娘結婚注オ戻所絶的御与わ" +
					"荷ム愛詳細表示").ToCharArray ();
			//		if (num == 2455)
			//		if (num == 2456)
			//		if (num == 2457)
			//		if (num == 2458)
			//		if (num == 2459)
			//		if (num == 2460)
			if (num == 2462)
				return "一回戦聖騎士ルヴィＶＳテンスベガー\u3000対ニドチェ決勝自由バジ".ToCharArray ();
			else
				return ("？あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽっゃゅょぁぃぅぇぉアイウ" +
				"エオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポッャュョァィゥェォヴゎヮ0123456789ABCDEFGHI" +
				"JKLMNOPQRSTUVWXYZー!?、。「」Σ'Д`∀ヾ゜дω・㌔㌧㌦㌍㌢ゝ秒abcdefghijklmnopqrstuvwxyz冬燦峰【】\u3000西我々眠見捨地人間私最後力大陸役立思許様他" +
				"干渉不幸招旅裏切神竜王類次時代委定族同士長苦戦現状正使限誰管理恐未来無関係墓暴解放玉永劫守仰一与彼支配者意志約束…争考少違本質的好認飽欲望進化鍵運命死言生物殺食動作弱肉強新世界摂甘自然愛草木重野獣性温" +
				"心信導目覚結果出残捧民救術教危機迫念資格仲知問題男狂気悪北沼封印責任待会談終日事託受証拠聖賜芳女何申破滅勇剣授手伝壁絵右光魔道書左宝黄金輝甲冑身暗黒向説今前御僕協話聞助願邪帝国侵略背度訳虐分悔騎誇味悟" +
				"上子軍内弟伯爵通以組敵方専門判断流水元十承行汝加護失探継描姿遣奇跡下団傍有由誉傭用要踊覧率轄屯侶了領剰輪麗歴偉録綺東友奉武至高是非卿勧礼先娘嘆兵多攻込座亡努務数年名参隊取避得決臆病熟詔婦預昨姪塞隣親派" +
				"公二乱始半市太優勢追詰求策注甦宿復活阻止老師実初典記恋悲落涙晶再遺存反崖静殿耐援到着余送簡共音沙括篭城続顔態打開安姫葉故唇奪笑南外布陣程規疲弊中募義訓練届集奴入報告所属明確馬鹿猛潔諸相困戻必変郷妃在抱" +
				"山賊征陛挙急宰保対持謝父海畑起恥侯遠場骸深負噂鵜呑絶罠論妥当早治回各防衛尽腰降期忠層働席主家冒涜議足近満片付口久修休喜頼直都合床伏歳政応逃快迎拶殊勝候恩揺留暮荒恨難差伸小頭皆侮痛末挨島貴暇忙嫌伺引煩怯" +
				"君帰達減真似騒面倒昔際姐俺張忘郎透丈夫連適緒耳健村警嘘赤興賭慢己体緊感欠律敢肩並売災冗去準備獲飛巡枚雇棒文句屁第割仕墜狩盗辺横襲撃住寄愚痴黙若祈統制群過利読基将荷担険炎形誓夢白想振叶福台詞慰縁貰血祭汰" +
				"怪昼闘答案散歩冷憎消価値建築朝夕閣令従陥突訪段平皇器万敗成就造短別特窟圧盾焦采牢構囚稼忍踏捕可店兄漢胸呼閉怖脱全部屋扉借酬払渋商買輸具衆額茶党請企騙筋縄妹風吹根巣奥洞覆雲延魂慌腕増隷母紙姉乞離寂返番街" +
				"旗厳隠祖旦港息官巫石像札幼町巻馳居計遅宮偽頃貸酒溜歌指単迷晴喫情寛広完河柄労密戒裕渡充呪誤異四採()収益靴泉泣濡拾赦浅恵乗誘拐謀討伐駒只聡誠慕評処遇斎客線千謳斐例件搬傷婚甥位臣狐退叔患露筒抜置鉄脚哀容" +
				"弾課贄拷刑闇吟遊詩呵/序章整及砦隙狙弁疑衣悠独杖予堅嗚威和腹震箱抵歓麻占犬刻惨抗品逸囲秘薬飲糸火射観怒良頑英雄繰罪史古移経腐階級沿岸点臨操月寝洗熱屈牧川泳溺惑天原営室字学礎田舎憶夜斥装妙業鎧揮精鋭首香" +
				"豚尻叩速走発畜燃途端毒焼朗被害臭慎標歯車刃為糧讐癒虫捜索湾越肥沃域擁敷帯版図搾貧憤権鎮粛清希包影百裔済契服陰積飢肝漁穫杯揃鷹牙睨押接損敬徳勘玄常謎料刀儡傀汚掘亀砲技極縛稽油駄詮供鼻触灸検虎叱監視驚痩弓" +
				"声孫廃矢悼給笛橋副幾撤側美拭船互潮壊脅訴易把握辛晩惜鎖跳窮崩掌随杞憂詳寒唱裂掠土揉境素皮厚比懐柔孤妻逆銀革紛森拓唯善乏司総潜花賞条檻虜嘲楽斬吐燻交絞吊弄費蹄棄周逝諦鳥養才能躍戮逗換調朽呟倉犠牲固鍛殻餞" +
				"狭毎埋折厄介表勲貨執赴酷狡猾税法蔵慣芸量泡紹泊滞納幽巧祥吸局因曲軽蔑貫蓄細工酔盟秩蜂僧猊嬢亭個卑劣遭育空角捉潰還蹴駆奸智購殲衝叡眼激瞬誕凄瞳拍慮咲庫波蘇葬湧召喚匹胃農選獄膨覇墟林狼択編画替示設範展停烏" +
				"穏齢這凶僻蛇療隔施慈青習冶砂丘等徒飼豊谷逐普尊員徴複雑傾扱懸勉羽匂傲穴朴仁斉栄験輩兼材骨双斧富即鮮ヶ賢芽節辞穢侍種堕蹂卵網列浄称粗低衰符試粉嬉攫挑財館控砕針米曇製康嫡障顧戯拒否如虚嫁腑紅染三唸販喉汁提" +
				"督稀遂灯況猶昏尋褒裁剥胆犯除袋浮里屠紋艦獅凡躾匿弔漠偵察倍軟禁貶児苛職庇拉致涯飾槍詫遥識岩旧后星髪冥祝駐功併両洲距弩挟超伍猟掛路抑拝混浪巨薄幻肌暑妾毛乳産痕忌迂却愉檄翼携般釈浴凌勤症厩巷雷講模投耗環勅" +
				"仇殴尚坊五算添醒托漆暖含舞遮沸号灰式秋儀恒歪社枢畏冴躙喧嘩貯仔殖貌献牛象魚那憧銘演沈語岬頂戴懲飯珍頻繁映煮埒悩盛織慨脈省埃傘八州隅筆妬峠嵐秀憐償錆辱汗謹系緯屍沢仮欺順絡愕濃徐脳績銅緑更底岳匠鳴罰七羊脂" +
				"婿賎励景央署壇繋緩宣睦恰隻締色豆寿縮蓮棲蛮氏賛効塔掃概唄勾寸鋒泥廷錯転叫微曽醜煉妨偶掟兆壮午凱儲痣槌烈疾徹俊敏瀕拡庶湖刺渾刹粋贅崇唐惚餓沖没怠看板鏡魅霧鬼璧劇凛培蒙昧藉悶蠢怨霊瘴蚊棺桶華雫雨逞禄抹寧贈" +
				"脹羨撒○×△□鋼登+餌飴釣鞭姑楯科諌翻擬簒迅掲瀬堂俗\"舌噛侭頬磨摘祟隼照酌~肖遍猫楚眉盲免雪翌帳茨膚競嬌丸爛漫畔宗院博冠姻純渇鈴癖凧丁浸貢賀豪罵宴鈍乙陽昇芯便戸源幕禍排促滴創郊玩堵宅房改些澄航摯－喪Ⅰ" +
				"ⅡⅢⅣⅤⅥⅦⅧⅨⅩ諾僅補ゐゑヰヱヵ熊喋錠鼓架※*既電♪削蒼氷嗜卓渓咄嗟#$&湿阿呆枠此惹幹拘.催擲依暦粒栗較韋睡揚詠疫蔓区彷徨遙砥銑矛診尾蝉煽駿♂♀爪拳茂池六麓,:;¨^￣＿―-\\∥|‥‘’“”〔〕[]" +
				"{}〈〉《》『』±÷=≠<>≦≧%§☆★●◎◇◆■▲▽▼→←↑↓АВГΔЕΖНΘΙКΛМΝΞОПРТΥФЧΨΩαβγδεζηθικλμνξοπρστυφχψ垣九岐寵球研樹蒸壺弦謁校賓園剤燕叙週＠＠辿維胎" +
				"瓦篤旨盆栽麦響脆箇項暫痺汎型竿壷噴凍蛾鱗耕亜鉛鉱錬隕譲頓憩醇克蕩沌馴虔徘徊宛査井汲碑貿綻推奨郭套灼載堪梁披幅贔屓嶺穀菜袈裟挽晒秤殉斃儚彫菩尖碧酵弐衡融疎哨薔薇縫陶鴨蟹淡酸爽薫庭炒蓋鶏兎茸羅貝柱苺季蜜塊鳳" +
				"凰髭硬粘幣溶橙屑牡猪鳩煎植鯨靱塵曜銛棍但妖嚇円盤捻銭淵煙妄胡述婆坑柵帆枯伴撹据眩濯慧臓雰奏桟医奮竹獰颯傑漏則塗珠蟲府吉趣廠洩諜捲聴罷袖循棚吏紳机絨毯磁瓶懺贖燈邸胞彩液琥珀享啓伊綴貼逢穿孔豹佐鉱帽絆膏扮潤" +
				"咳竪琴祓訛筈咬綿賦乾喘宜峙譜溢憬債童芝嫉拗矜囁垢雅苗篇猜毅囮陪卒暁扇站蒐絹蚤奔眺賃樽詣掴審懇畳藁膠測牽憑蹟逮楔巾涼薦械霞串漂塩頁瞭詐碍奢籍雛晰拵藪鞍牝僚究冊媚賑虹恭蒔鋤搭憲刈裾捌蝕鞘倹泰爺兜呈＠＠＠＠＠" +
				"＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠" +
				"＠＠＠＠＠＠＠＠＠").ToCharArray ();
		}
	}
}
