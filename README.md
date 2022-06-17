# UintyのURPでGPUInstancing  
 1:C#側から最初にGPUメモリに座標を格納  
 2:ShaderでGPUメモリから座標を取得  
 3:影付き(castShadow)でレンダリング&SSAO適応
 
# 仕様  
 サンプルはForwardでレンダリングしていますが、Defferedにしたいなら URP-HighFidelity-Renderer のレンダリングパスをDefferedにして、GPUInstancingShaderのForward部分をコメントアウトしてUniversalGBuffer部分のコメントアウトを外してください。そしてUniversalGBufferのPassを必要に応じSubShader内の一番上に移動させてください。  
 MyShaderMaterialのAlphaClippingにチェックをつけると貼り付けたテクスチャの透過設定ができます。  
 
# イメージ  

![image](https://user-images.githubusercontent.com/44022497/174307537-7cecb9a8-3de5-4a7b-bab9-ed6f8df23a6a.jpg)

 黄色がGPUインスタンシングで描画したCube、後ろの白いのは標準Lit ShaderのSphereとCube  
 しっかり影が落ちていて、かつURP標準のSSAOが適応できている  