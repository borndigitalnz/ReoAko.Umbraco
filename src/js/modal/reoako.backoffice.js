import { modalcss } from "./reoako.backoffice.scss";

(() => {
    let searchTerm;
    let form = document.getElementById("reoako-search-form");
    form.addEventListener("submit", function (event) {
        event.preventDefault();
        searchTerm = this.elements["search-term"].value;
        if (searchTerm === "") return;
            
        performSearch(searchTerm);
    });
    let resultsNode = document.getElementById("reoako-search-results");
    let reoakoInstance = window.parent._reoako;
    let editor = reoakoInstance.features.editor;

    // perform search on load if initialised with search term
    searchTerm = form.elements["search-term"].value;
    if (searchTerm !== "") performSearch(searchTerm);

    resultsNode.addEventListener("click", function (event) {
        if (event.target && event.target.closest(".reoako-choose-word")) {
            event.preventDefault();
            let link = event.target.closest(".reoako-choose-word");
            let id = link.getAttribute("data-reoako-id");
            let word = link.getAttribute("data-reoako-translation");

            let editorContentToInsert = `<span class="reoako-term" data-reoako-id="${id}">${word}</span>`;
            editor.insertContent(editorContentToInsert);
            reoakoInstance.close();
        }
    });

    function performSearch(searchTerm) {

        fetch("/umbraco/api/reoakosearch/search?searchTerm=" + searchTerm, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then((response) => response.json())
            .then((data) => displayResults(data))
            .catch((error) => {
                alert("There was a problem searching ReoAko - check your API key.");
            });
    }
    function displayResults(results) {
        let resultsHtml = `<p class="results-count">There are ${results.length} results for "${searchTerm}"</p>`;
        if (results.length === 0) {
            resultsNode.innerHTML = resultsHtml;
            return;
        }
        resultsHtml += `<table>`;
        resultsHtml += `
<tr>
    <th>Term</th>
    <th>Function</th>
    <th>Definition</th>
</tr>`;
        for (let item of results) {
            resultsHtml += `
<tr>
    <td>
        <a class="reoako-choose-word"
           href="#${item.translations[0].slug}"
           data-reoako-id="${item.translations[0].slug}"
           data-reoako-headword="${item.headword}"
           data-reoako-translation="${item.translations[0].mi}">
            <strong>${item.translations[0].mi}</strong><br>
            ${item.translations[0].en}
        </a>
    </td>
    <td>${item.function}</td>
    <td>${item.definition}</td>
</tr>`;
        }
        resultsHtml += `</table>`;
        resultsNode.innerHTML = resultsHtml;
    }
})();
