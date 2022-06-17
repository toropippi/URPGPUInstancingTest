# UintyのURPでGPUInstancing  
 1 : C#側から最初にGPUメモリ(Compute Buffer)に座標を格納  
 2 : Shader側でGPUメモリから座標を取得  
 3 : Graphics.DrawMeshInstancedIndirectでcastShadowのPassとDepthNormalsのPass込みでレンダリング→影付き&SSAO適応の完成
 
## やっていること
 https://notargs.hateblo.jp/entry/lwrp_particle を参考にURPの標準Lit Shaderを一部書き換え  
 Lit Shaderがincludeしている各Passのソースコードをコピペしてちょっと書き換え  
 ・標準のLitForwardPass→LitForwardPass2  
 ・標準のLitGBufferPass→LitGBufferPass2  
 ・標準のShadowCasterPass→ShadowCasterPass2  
 ・標準のDepthOnlyPass→DepthOnlyPass2  
 ・標準のLitDepthNormalsPass→LitDepthNormalsPass2  
 
## 仕様  
 サンプルはForwardでレンダリングしていますが、Defferedにしたいなら URP-HighFidelity-Renderer のレンダリングパスをDefferedにして、GPUInstancingShaderのForward部分をコメントアウトしてUniversalGBuffer部分のコメントアウトを外してください。そしてUniversalGBufferのPassを必要に応じSubShader内の一番上に移動させてください。  
 MyShaderMaterialのAlphaClippingにチェックをつけると貼り付けたテクスチャの透過設定ができます。  
 
## イメージ  

![image](https://user-images.githubusercontent.com/44022497/174307537-7cecb9a8-3de5-4a7b-bab9-ed6f8df23a6a.jpg)

 黄色がGPUインスタンシングで描画したCube、後ろの白いのは標準Lit ShaderのSphereとCube  
 しっかり影が落ちていて、かつURP標準のSSAOが適応できているのが分かる  