# Unity Action Kullanımı

Merhabalar! Bu belge, Unity Action'un ne olduğunu, nerelerde kullanılabileceğini ve nasıl kullanıldığını anlatmaktadır.

## Unity Action Nedir?

Unity Action, delegate yapısına benzeyen ve birden fazla fonksiyonu içinde tutabilen bir yapıdır. Bu yapı sayesinde aynı anda birden fazla fonksiyonu çalıştırabiliriz. Unity Action sınıfı genellikle static olarak tanımlanır, bu da diğer sınıflarda bu sınıfı get etmeye gerek kalmadan doğrudan Unity Action'u çalıştırabilmemize olanak tanır.

## Unity Action Nerelerde Kullanılır?

Unity Action'u kullanarak örneğin bir skor sistemi için kullanabiliriz. Sahnede birden fazla düşman olduğunu varsayarsak, bu düşmanlara ateş edildiğinde ne tür işlemler gerçekleşeceğini Unity Action içine atarak tek bir yerden birçok fonksiyonu çalıştırabiliriz.

Örneğin, bir karakteri öldürdüğümüzde oyuncunun skorunu artırmak ve ölen karakteri sahneden silmek isteyebiliriz.

## Unity Action Nasıl Kullanılır?

Öncelikle, basit bir `Actions` sınıfı oluşturalım:

```csharp
using System;

public static class Actions
{
    public static Action OnEnemyKilled;
}
```

Şimdi, bir `Enemy` sınıfı oluşturalım:

```csharp
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    public float enemySpeed;

    public void EnemyMove()
    {
        this.transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }

    private void EnemyKilled()
    {
        Actions.OnEnemyKilled?.Invoke();
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            EnemyKilled();
    }
}
```

Bu örnek, düşman öldürüldüğünde `OnEnemyKilled` Action'ını çağırır ve aynı zamanda düşmanı sahneden siler.
