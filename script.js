// قائمة المنتجات
const products = [
    {
        id: 1,
        name: "لابتوب ديل XPS 13",
        price: 450,
        emoji: "💻",
        description: "لابتوب عالي الأداء"
    },
    {
        id: 2,
        name: "قميص قطني أزرق",
        price: 120,
        emoji: "👔",
        description: "قميص أنيق للعمل"
    },
    {
        id: 3,
        name: "كتاب البرمجة",
        price: 85,
        emoji: "📚",
        description: "تعلم البرمجة من الصفر"
    },
    {
        id: 4,
        name: "حذاء رياضي نايكي",
        price: 280,
        emoji: "👟",
        description: "حذاء مريح للرياضة"
    },
    {
        id: 5,
        name: "هاتف آيفون 14",
        price: 650,
        emoji: "📱",
        description: "أحدث هاتف ذكي"
    },
    {
        id: 6,
        name: "جاكيت شتوي",
        price: 220,
        emoji: "🧥",
        description: "دافئ وأنيق"
    },
    {
        id: 7,
        name: "كتاب التاريخ",
        price: 65,
        emoji: "📖",
        description: "تاريخ مصر القديمة"
    },
    {
        id: 8,
        name: "كرة قدم أديداس",
        price: 150,
        emoji: "⚽",
        description: "كرة احترافية"
    },
    {
        id: 9,
        name: "سماعات بلوتوث",
        price: 320,
        emoji: "🎧",
        description: "صوت عالي الجودة"
    },
    {
        id: 10,
        name: "فستان أنيق",
        price: 180,
        emoji: "👗",
        description: "للمناسبات الخاصة"
    },
    {
        id: 11,
        name: "رواية عربية",
        price: 45,
        emoji: "📘",
        description: "أدب معاصر"
    },
    {
        id: 12,
        name: "دراجة هوائية",
        price: 550,
        emoji: "🚴",
        description: "للرياضة والتنقل"
    },
    {
        id: 13,
        name: "ساعة ذكية أبل",
        price: 380,
        emoji: "⌚",
        description: "تتبع الصحة واللياقة"
    },
    {
        id: 14,
        name: "حقيبة ظهر",
        price: 95,
        emoji: "🎒",
        description: "مناسبة للمدرسة والجامعة"
    },
    {
        id: 15,
        name: "كاميرا رقمية",
        price: 420,
        emoji: "📷",
        description: "التقط أجمل اللحظات"
    },
    {
        id: 16,
        name: "نظارة شمسية",
        price: 75,
        emoji: "🕶️",
        description: "حماية وأناقة"
    },
    {
        id: 17,
        name: "آلة حاسبة علمية",
        price: 55,
        emoji: "🔢",
        description: "للطلاب والمهندسين"
    },
    {
        id: 18,
        name: "مكبر صوت بلوتوث",
        price: 190,
        emoji: "🔊",
        description: "صوت قوي ونقي"
    },
    {
        id: 19,
        name: "كتاب الطبخ",
        price: 70,
        emoji: "👨‍🍳",
        description: "وصفات شهية ومتنوعة"
    },
    {
        id: 20,
        name: "لعبة شطرنج",
        price: 85,
        emoji: "♟️",
        description: "لعبة العقول"
    }
];

// سلة المشتريات
let cart = [];

// عرض المنتجات
function renderProducts() {
    const productsContainer = document.getElementById('products');
    const searchTerm = document.getElementById('search').value.toLowerCase();
    const filterValue = document.getElementById('filter').value;
    
    // تصفية المنتجات
    let filteredProducts = products.filter(product => {
        const matchesSearch = product.name.toLowerCase().includes(searchTerm);
        let matchesFilter = true;
        
        switch(filterValue) {
            case 'cheap':
                matchesFilter = product.price < 200;
                break;
            case 'mid':
                matchesFilter = product.price >= 200 && product.price <= 300;
                break;
            case 'expensive':
                matchesFilter = product.price > 300;
                break;
            default:
                matchesFilter = true;
        }
        
        return matchesSearch && matchesFilter;
    });
    
    // عرض المنتجات
    if (filteredProducts.length === 0) {
        productsContainer.innerHTML = '<div class="no-products">لا توجد منتجات تطابق البحث</div>';
        return;
    }
    
    productsContainer.innerHTML = filteredProducts.map(product => `
        <div class="product">
            <div class="product-image">${product.emoji}</div>
            <div class="product-info">
                <h3>${product.name}</h3>
                <p>${product.description}</p>
                <div class="price">${product.price} جنيه</div>
                <button onclick="addToCart(${product.id})" id="btn-${product.id}">
                    إضافة للسلة
                </button>
            </div>
        </div>
    `).join('');
}

// إضافة منتج للسلة
function addToCart(productId) {
    const product = products.find(p => p.id === productId);
    const existingItem = cart.find(item => item.id === productId);
    
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cart.push({ ...product, quantity: 1 });
    }
    
    // تأثير بصري للإضافة
    const button = document.getElementById(`btn-${productId}`);
    button.textContent = 'تم الإضافة!';
    button.classList.add('added');
    
    setTimeout(() => {
        button.textContent = 'إضافة للسلة';
        button.classList.remove('added');
    }, 1000);
    
    renderCart();
}

// تحديث الكمية
function updateQuantity(productId, change) {
    const item = cart.find(item => item.id === productId);
    if (item) {
        item.quantity += change;
        if (item.quantity <= 0) {
            removeFromCart(productId);
        } else {
            renderCart();
        }
    }
}

// حذف منتج من السلة
function removeFromCart(productId) {
    cart = cart.filter(item => item.id !== productId);
    renderCart();
}

// عرض السلة
function renderCart() {
    const cartContainer = document.getElementById('cart');
    const totalElement = document.getElementById('total');
    
    if (cart.length === 0) {
        cartContainer.innerHTML = '<div class="empty-cart">🛒 السلة فارغة - ابدأ التسوق الآن!</div>';
        totalElement.textContent = 'المجموع: 0 جنيه';
        return;
    }
    
    const cartHTML = cart.map(item => `
        <div class="cart-item">
            <div class="cart-item-info">
                <h4>${item.emoji} ${item.name}</h4>
                <div class="item-price">${item.price} جنيه × ${item.quantity} = ${item.price * item.quantity} جنيه</div>
            </div>
            <div class="quantity-controls">
                <button class="qty-btn" onclick="updateQuantity(${item.id}, -1)">-</button>
                <span class="quantity">${item.quantity}</span>
                <button class="qty-btn" onclick="updateQuantity(${item.id}, 1)">+</button>
                <button class="remove-btn" onclick="removeFromCart(${item.id})">حذف</button>
            </div>
        </div>
    `).join('');
    
    cartContainer.innerHTML = cartHTML;
    
    // حساب المجموع
    const total = cart.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    totalElement.textContent = `المجموع: ${total.toLocaleString()} جنيه`;
}

// إفراغ السلة
function clearCart() {
    if (cart.length === 0) {
        alert('السلة فارغة بالفعل!');
        return;
    }
    
    if (confirm('هل أنت متأكد من إفراغ السلة؟')) {
        cart = [];
        renderCart();
        
        // تأثير بصري
        const clearBtn = document.querySelector('.clear-btn');
        clearBtn.textContent = 'تم الإفراغ!';
        clearBtn.style.background = 'linear-gradient(45deg, #2ed573, #1e90ff)';
        
        setTimeout(() => {
            clearBtn.textContent = 'إفراغ السلة';
            clearBtn.style.background = 'linear-gradient(45deg, #ff4757, #ff6b7a)';
        }, 2000);
    }
}

// إضافة وظائف إضافية
function smoothScroll(target) {
    document.querySelector(target).scrollIntoView({
        behavior: 'smooth'
    });
}

// تحديث عدد المنتجات في العنوان
function updateCartCount() {
    const totalItems = cart.reduce((sum, item) => sum + item.quantity, 0);
    const cartLink = document.querySelector('a[href="#cart"]');
    if (totalItems > 0) {
        cartLink.textContent = `Basket (${totalItems})`;
    } else {
        cartLink.textContent = 'Basket';
    }
}

// تعديل دالة renderCart لتحديث العداد
const originalRenderCart = renderCart;
renderCart = function() {
    originalRenderCart();
    updateCartCount();
};

// إضافة بحث متقدم
function advancedSearch() {
    const searchTerm = document.getElementById('search').value.toLowerCase();
    if (searchTerm.length < 2) {
        renderProducts();
        return;
    }
    
    const results = products.filter(product => {
        return product.name.toLowerCase().includes(searchTerm) ||
               product.description.toLowerCase().includes(searchTerm);
    });
    
    if (results.length === 0) {
        document.getElementById('products').innerHTML = 
            `<div class="no-products">
                <h3>لا توجد نتائج للبحث عن "${searchTerm}"</h3>
                <p>جرب البحث بكلمات أخرى</p>
            </div>`;
        return;
    }
    
    // عرض النتائج مع تمييز النص المطابق
    const productsContainer = document.getElementById('products');
    productsContainer.innerHTML = results.map(product => {
        let highlightedName = product.name.replace(
            new RegExp(searchTerm, 'gi'), 
            match => `<mark style="background: linear-gradient(45deg, #667eea, #764ba2); color: white; padding: 2px 4px; border-radius: 3px;">${match}</mark>`
        );
        
        return `
            <div class="product">
                <div class="product-image">${product.emoji}</div>
                <div class="product-info">
                    <h3>${highlightedName}</h3>
                    <p>${product.description}</p>
                    <div class="price">${product.price} جنيه</div>
                    <button onclick="addToCart(${product.id})" id="btn-${product.id}">
                        إضافة للسلة
                    </button>
                </div>
            </div>
        `;
    }).join('');
}

// إضافة اختصارات لوحة المفاتيح
document.addEventListener('keydown', function(e) {
    // Ctrl + F للبحث
    if (e.ctrlKey && e.key === 'f') {
        e.preventDefault();
        document.getElementById('search').focus();
    }
    
    // Escape لإفراغ البحث
    if (e.key === 'Escape') {
        document.getElementById('search').value = '';
        renderProducts();
    }
});

// إضافة تأثيرات صوتية (اختيارية)
function playSound(type) {
    // يمكن إضافة أصوات للتفاعلات المختلفة
    try {
        const audio = new Audio();
        switch(type) {
            case 'add':
                // صوت إضافة للسلة
                break;
            case 'remove':
                // صوت حذف من السلة
                break;
            case 'clear':
              // صوت إفراغ السلة  
         break;
            default:
                return;
        }
        audio.play();
    } catch (error) {
        console.warn('تعذر تشغيل الصوت:', error);
    }
}

// تهيئة التطبيق
document.addEventListener('DOMContentLoaded', () => {
    renderProducts();
    renderCart();
});
            