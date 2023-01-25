# SimpleSampleSafeAreaAndCutouts
This repository is a sample of safe area and cutouts.

## 概要

UnityEngine.Screen.[safeArea](https://docs.unity3d.com/ja/current/ScriptReference/Screen-safeArea.html)とUnityEngine.Screen.[cutouts](https://docs.unity3d.com/ja/current/ScriptReference/Screen-cutouts.html)を確認する為のサンプルです。

## 検証環境

使用しているUnityのバージョンはUnity2021.3.13f1です。(スクリプトリファレンスにはsafeAreaはUnity2017.2、cutoutsはUnty2019.4から記載があります）
Android,iOSプラットフォームに関して検証を行っており、Androidに関してはPixel3XL(実機)とAndroidエミュレーター、iOSに関してはiPhone11(実機)とiPhone14(Simulator)で確認をおこなっています。
また、[こちら](https://developer.android.com/guide/topics/display-cutout?hl=ja)のページによるとAndroidでcutoutsはAndroid 9(API レベル 28)以降の端末でcutoutsで対応と記載がありますのでご注意下さい。

## 検証内容

以下の表の順番と内容で矩形の描画を行っています。

|Color|内容|
|:---:|:-:|
|赤|画面全体|
|青|safeAreaの範囲|
|緑|cutoutsの範囲|

## 実行結果

現時点では、AndroidではsafeAreaとcutoutsの両方、iOSではsafeAreaのみ対応しているように見えます。

### Android

#### Pixel3XLを撮影した結果と画面をキャプチャーの比較

<img width="200" alt="Pixel3XL" src="https://user-images.githubusercontent.com/29646672/214475108-9dbc1910-da97-41df-853a-0a4e2b42fb7d.jpg">
<img width="200" alt="Pixel3XL Capture" src="https://user-images.githubusercontent.com/29646672/214475190-42213393-ae81-44a4-b66a-6c94c5d086b7.png">

#### Androidエミュレーターでの比較

##### punch hole

<img width="200" alt="punch hole" src="https://user-images.githubusercontent.com/29646672/214474386-b3bb4a6a-cfc8-43ee-86f7-98969c04a474.png">

##### double

<img width="200" alt="double" src="https://user-images.githubusercontent.com/29646672/214475471-82f738c9-ac5f-4e15-9159-99fb69a63fb4.png">

##### corner

<img width="200" alt="corner" src="https://user-images.githubusercontent.com/29646672/214475520-98f500c6-cd43-4d65-ac25-62c6391b0b87.png">


### iOS

iOSではcutoutsを取得するAPIをAppleが提供していない為、Unityの中で端末毎のパラメータを埋め込んでいます。その為、Unityのバージョンによってはcutoutsの値が取れない端末が発生します。
Unity2021.3.13f1ではiPhone14系の端末のcutoutsの情報が含まれていません。
詳細に関しては、Unityが出力したxcodeプロジェクトに含まれる、UnityView.mmで定義されているGetCutoutToScreenRatio()を確認して下さい。

#### iPhone11

<img width="200" alt="iPhone14Pro" src="https://user-images.githubusercontent.com/29646672/214514139-554df98f-969e-4b26-88ad-736981133559.png">

#### iPhone14Pro(Simulator)

<img width="200" alt="iPhone14Pro" src="https://user-images.githubusercontent.com/29646672/214476352-7cc785d8-d360-4050-8cec-bcc7c9c1bcf3.png">
<img width="200" alt="iPhone14Pro" src="https://user-images.githubusercontent.com/29646672/214476491-06e96efb-1720-4aa4-a0eb-3a4325f681ec.png">

以上


