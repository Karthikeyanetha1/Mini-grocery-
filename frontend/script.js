const apiUrl = "http://localhost:5000";

// Load products
fetch(apiUrl + "/products")
    .then(res => res.json())
    .then(data => {
        const list = document.getElementById("productList");
        data.forEach(p => {
            const li = document.createElement("li");
            li.innerText = `${p.id} - ${p.name} (Stock: ${p.stock})`;
            list.appendChild(li);
        });
    });

// Place order
function placeOrder() {
    const productId = document.getElementById("productId").value;
    const quantity = document.getElementById("quantity").value;

    fetch(apiUrl + "/orders", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            productId: Number(productId),
            quantity: Number(quantity)
        })
    })
    .then(res => res.text())
    .then(msg => {
        document.getElementById("message").innerText = msg;
    });
}
