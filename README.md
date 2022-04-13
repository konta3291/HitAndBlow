# Hit and Blow

Gitの使い方や、作業の流れを理解するための課題用。  

## 使い方

1. GitHubで、画面右上の`Fork`をクリックし、自分のユーザー名を選択
    - Gitを知らない人向けに説明すると、Forkはコピーみたいなものと思っていい
1. Forkした自分のリポジトリを、PCに`Clone`する
    1. GitHubで、画面中央付近の緑色の`Code▼`をクリック
    1. `SSH`タブを選択し、`git@auto3tsv132:(自分のID)/Hit-and-Blow.git`をコピー
    1. GitBashで`git clone git@～(先程コピーしたもの)`を叩く
        - Bashでの貼り付け操作は`Shift`+`Insert`
1. Submoduleを初期化する
    - Gitで`git submodule update --init`を叩く
1. 作業する
