# Unity_FontManager
Unityで、TextのFontをグループ分けしてFontを設定するやつ。

### 使い方
- Hierarchyの一番上にPrefabフォルダの中にある「FontManager」を置く
- FontManagerの中身を編集する
- TextにFontSetterをアタッチする
- FontSetterを設定する

### Tips
- FontManagerがHierarchyに存在しない場合、FontSetterをアタッチすると自動的にFontManagerが生成されます。
- FontSetterは自動的にFontManagerを取得します。
- Editor上でのみFontManagerの取得・フォントの変更を行うのでプレイの動作には影響しません。
- FontManagerをdisableにした状態だとFontSetterはFontManagerを認識できません。