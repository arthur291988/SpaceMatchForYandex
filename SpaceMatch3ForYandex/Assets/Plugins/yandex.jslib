
mergeInto(LibraryManager.library, {

 
  BuyNoAds: function () {
    payments.purchase({ id: 'noAds' }).then(purchase => {
        // Покупка успешно совершена!
      myGameInstance.SendMessage('IAPManager', 'buyNoAdsFromMenuResult');

    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })

  },

  CheckNoAds: function () {
    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === 'noAds')) {
            myGameInstance.SendMessage('IAPManager', 'buyNoAdsFromMenuResult');
        }
    }).catch(err => {
        // Выбрасывает исключение USER_NOT_AUTHORIZED для неавторизованных пользователей.
    })
  },

  BuyNoAdsSpecial: function () {

    payments.purchase({ id: 'noAdsSpecial' }).then(purchase => {
        // Покупка успешно совершена!
      myGameInstance.SendMessage('IAPManager', 'buyNoAdsSpecialResult');

    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
  },

  CheckNoAdsSpecial: function () {
    payments.getPurchases().then(purchases => {
        if (purchases.some(purchase => purchase.productID === 'noAdsSpecial')) {
            myGameInstance.SendMessage('IAPManager', 'buyNoAdsSpecialResult');
        }
    }).catch(err => {
        // Выбрасывает исключение USER_NOT_AUTHORIZED для неавторизованных пользователей.
    })
  },


  RateGame: function () {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        myGameInstance.SendMessage('MenuManager', 'rateUsResult');
                    })
            } else {
                console.log(reason)
            }
        })
  },


  SaveExtern: function (data) {
    var dataString = UTF8ToString(data);
    var myObj = JSON.parse(dataString);
    player.setData (myObj);

  },

  LoadExtern: function () {
    player.getData().then(_data => {
        const myJSON = JSON.stringify(_data);
        myGameInstance.SendMessage('SaveAndLoad', 'loadData', myJSON);

    });

    
  },

  ShowAds: function () {

        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                  myGameInstance.SendMessage('GameManager', 'afterAdsShown');
                },
                onError: function(error) {
                  myGameInstance.SendMessage('GameManager', 'checkTheInternet');
                }
            }
        })

    },


});