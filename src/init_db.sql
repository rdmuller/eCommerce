Estoque
{
	//-----------------------------------------------------------------------------------------------//
	// L O T E 
	//-----------------------------------------------------------------------------------------------//
	
	[RestMethod(POST)]
	[RestPath("v1/lotes")]
	IncluirLote(in:&doc, in:&lote, out:&output_schema)
	=> BaseERP.Estoque.GravarLote(&SdtSessao, &lote_id, &lote, &output_schema, &RestCode);
	
	[RestMethod(PUT)]
	[RestPath("v1/lotes/{&lote_id}")]
	IncluirLote(in:&doc, in:&lote_id, in:&lote, out:&output_schema)
	=> BaseERP.Estoque.GravarLote(&SdtSessao, &lote_id, &lote, &output_schema, &RestCode);
	
	[RestMethod(DELETE)]
	[RestPath("v1/lotes/{&lote_id}")]
	ExcluirLote(in:&lote_id, out:&output_schema)
	=> BaseERP.Estoque.ExcluirLote(&SdtSessao, &lote_id, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/lotes/{&lote_id}")]
	RetSdtLote(in:&lote_id, out:&lote, out:&output_schema)
	=> BaseERP.Estoque.RetSdtLote(&SdtSessao, &lote_id, 0, "", &lote, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/lotes")]
	RetListaLotes(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&lotes)
	=> BaseERP.Estoque.RetSdtLotes(&SdtSessao, &SdtInputGet, &lotes, &RestCode);
	
	//-----------------------------------------------------------------------------------------------//
	// M O V I M E N T O
	//-----------------------------------------------------------------------------------------------//

	[RestMethod(POST)]
	[RestPath("v1/movimentos")]
	IncluirMovimento(in:&doc, in:&movimento_estoque, out:&output_schema)
	=> BaseERP.Estoque.IncluirMovimento(&SdtSessao, &movimento_estoque, true, &output_schema, &RestCode);
	
	[RestMethod(DELETE)]
	[RestPath("v1/movimentos/{&movimento_id}")]
	ExcluirMovimento(in:&movimento_id, out:&output_schema)
	=> BaseERP.Estoque.ExcluirMovimento(&SdtSessao, &movimento_id, true, &output_schema, &RestCode);
	
	[Description("Retornar movimentos do estoque")]
	[RestMethod(GET)]
	[RestPath("v1/movimentos")]
	RetListaMovimentos(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&movimentos)
	=> BaseERP.Estoque.RetSdtMovimentos(&SdtSessao, &SdtInputGet, &movimentos, &RestCode);
	
	//-----------------------------------------------------------------------------------------------//
	// S A L D O S
	//-----------------------------------------------------------------------------------------------//
	
	[RestMethod(POST)]
	[RestPath("v1/saldos-reprocessar")]
	ReprocessarSaldo(in:&doc, in:&reprocessar_saldo, out:&output_schema)
	=> BaseERP.Estoque.ReprocessarSaldo(&SdtSessao, &reprocessar_saldo, true, &output_schema, &RestCode);

	[Description("Retornar o saldo por produto-AX-PE-lote")]
	[RestMethod(GET)]
	[RestPath("v1/saldos/produto/{&produto_id}")]
	RetListaProdutoSaldos(in:&produto_id, in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&saldos)
	=> BaseERP.Estoque.RetSdtProdutoSaldos(&SdtSessao, &SdtInputGet, &produto_id, &saldos, &RestCode);
	
	//-----------------------------------------------------------------------------------------------//
	// B A L A N Ç O
	//-----------------------------------------------------------------------------------------------//
	
	[RestMethod(POST)]
	[RestPath("v1/balancos")]
	IncluirBalanco(in:&doc, in:&balanco, out:&output_schema)	
	=> BaseERP.Estoque.GravarBalanco(&SdtSessao, &balanco_id, &balanco, &output_schema, &RestCode);
	
	[RestMethod(PUT)]
	[RestPath("v1/balancos/{&balanco_id}")]
	AlterarBalanco(in:&doc, in:&balanco_id, in:&balanco, out:&output_schema)
	=> BaseERP.Estoque.GravarBalanco(&SdtSessao, &balanco_id, &balanco, &output_schema, &RestCode);
	
	[RestMethod(DELETE)]
	[RestPath("v1/balancos/{&balanco_id}")]
	ExcluirBalanco(in:&balanco_id, out:&output_schema)	
	=> BaseERP.Estoque.ExcluirBalanco(&SdtSessao, &balanco_id, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos/{&balanco_id}")]
	RetSdtBalanco(in:&balanco_id, out:&balanco, out:&output_schema)
	=> BaseERP.Estoque.RetSdtBalanco(&SdtSessao, &balanco_id, &balanco, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos")]
	RetListaBalancos(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&balancos)
	=> BaseERP.Estoque.RetSdtBalancos(&SdtSessao, &SdtInputGet, &balancos, &RestCode);

	[RestMethod(POST)]
	[RestPath("v1/balancos/{&balanco_id}/produtos/")]
	GravarBalancoProdutos(in:&doc, in:&balanco_id, in:&produtos, out:&output_schema)
	=> BaseERP.Estoque.GravarBalancoProdutos(&SdtSessao, &produtos, &balanco_id, "M", &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos/{&balanco_id}/produtos/{&produto_id}")]
	RetSdtBalancoProduto(in:&balanco_id, in:&produto_id, out:&balanco_produtos, out:&output_schema)
	=> BaseERP.Estoque.RetSdtBalancoProduto(&SdtSessao, &balanco_id, &produto_id, &balanco_produtos, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos/{&balanco_id}/produtos")]
	RetListaBalancoProdutos(in:&balanco_id, in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&balancos_produtos)
	=> BaseERP.Estoque.RetSdtBalancoProdutos(&SdtSessao, &SdtInputGet, &balanco_id, True, &balancos_produtos, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos/produtos/list")]
	RetListaBalancosProdutos(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&balancos_produtos)
	=> BaseERP.Estoque.RetSdtBalancoProdutos(&SdtSessao, &SdtInputGet, &balanco_id, False, &balancos_produtos, &RestCode);
	
	[RestMethod(POST)]
	[RestPath("v1/balancos/ajustes/gerar")]
	GerarBalancoAjustes(in:&doc, in:&ajuste_balanco, out:&output_schema)
	=> BaseERP.Estoque.GerarBalancoAjustes(&SdtSessao, &ajuste_balanco, &output_schema, &RestCode);
	
	[RestMethod(POST)]
	[RestPath("v1/balancos/ajustes/estornar")]
	GerarBalancoEstornos(in:&doc, in:&ajuste_balanco, out:&output_schema)
	=> BaseERP.Estoque.GerarBalancoEstornos(&SdtSessao, &ajuste_balanco, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/balancos/exportar/xlsx")]
	GerarBalancoXlsx(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&balancos_produtos)
	=> BaseERP.Estoque.RetXlsxBalancoProdutos(&SdtSessao, &SdtInputGet, &balancos_produtos, &RestCode);
	
	[RestMethod(POST)]
	[RestPath("v1/balancos/importar/xlsx")]
	ImportarBalancoXlsx(in:&doc, in:&xlsx_base64, out:&output_schema)
	=> BaseERP.Estoque.ImportarBalancoProdutos(&SdtSessao, &xlsx_base64, &output_schema, &RestCode);
	
	//-----------------------------------------------------------------------------------------------//
	// I N V E N T Á R I O 
	//-----------------------------------------------------------------------------------------------//

	[RestMethod(POST)]
	[RestPath("v1/inventarios")]
	GerarInventario(in:&doc, in:&inventario, out:&output_schema)
	=> BaseERP.Estoque.GerarInventario(&SdtSessao, &inventario, False, &output_schema, &RestCode);
	
	[RestMethod(DELETE)]
	[RestPath("v1/inventarios")]
	ExcluirInventario(in:&almoxarifado_id, in:&ano, in:&mes,out:&output_schema)
	=> BaseERP.Estoque.ExcluirInventario(&SdtSessao, &almoxarifado_id, &ano, &mes, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/inventarios")]
	RetListaInventarios(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&inventarios)
	=> BaseERP.Estoque.RetSdtInventarios(&SdtSessao, &SdtInputGet, &inventarios, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/inventarios/produtos")]
	RetListaInventarioProdutos(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&inventario_produtos)
	=> BaseERP.Estoque.RetSdtInventarioProdutos(&SdtSessao, &SdtInputGet, &inventario_produtos, &RestCode);
	
	[RestMethod(PUT)]
	[RestPath("v1/inventarios/produtos/valores")]
	GerarInventarioProdutoValor(in:&doc, in:&doc, in:&inventario_produto_valor, out:&output_schema)
	=> BaseERP.Estoque.AtualizarInventarioProdutoValor(&SdtSessao, &inventario_produto_valor, &output_schema, &RestCode);
	
	[RestMethod(POST)]
	[RestPath("v1/inventarios/ajustes-financeiros")]
	GerarInventarioAjustes(in:&doc, in:&inventario, out:&output_schema)
	=> BaseERP.Estoque.GerarInventarioAjustes(&SdtSessao, &inventario, &output_schema, &RestCode);
	
	[RestMethod(DELETE)]
	[RestPath("v1/inventarios/ajustes-financeiros")]
	ExcluirInventarioAjustes(in:&almoxarifado_id, in:&ano, in:&mes, out:&output_schema)
	=> BaseERP.Estoque.ExcluirInventarioAjustes(&SdtSessao, &almoxarifado_id, &ano, &mes, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/inventarios/exportar/xlsx")]
	GerarInventarioProdutosXlsx(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&inventario_produtos)
	=> BaseERP.Estoque.RetXlsxInventarioProdutos(&SdtSessao, &SdtInputGet, &inventario_produtos, &RestCode);
	
	[RestMethod(POST)]
	[RestPath("v1/inventarios/importar/xlsx")]
	ImportarInventarioXlsx(in:&doc, in:&xlsx_base64, out:&output_schema)
	=> BaseERP.Estoque.ImportarInventarioProdutos(&SdtSessao, &xlsx_base64, &output_schema, &RestCode);
	
	//-----------------------------------------------------------------------------------------------//
	// R E C L A S S I F I C A Ç Ã O 
	//-----------------------------------------------------------------------------------------------//
	
	[Description("Incluir uma reclassificacao")]
	[RestMethod(POST)]
	[RestPath("v1/reclassificacoes/incluir")]
	IncluirReclassificacao(in:&doc, in:&reclassificacao, out:&output_schema)
	=> BaseERP.Estoque.GravarReclassificacao(&SdtSessao, &reclassificacao, &output_schema, &RestCode);
	
	[Description("Estornar uma reclassificacao")]
	[RestMethod(POST)]
	[RestPath("v1/reclassificacoes/estornar/{&reclassificacao_id}")]
	EstornarReclassificacao(in:&doc, in:&reclassificacao_id, out:&output_schema)
	=> BaseERP.Estoque.EstornarReclassificacao(&SdtSessao, &reclassificacao_id, &output_schema, &RestCode);
	
	[RestMethod(GET)]
	[RestPath("v1/reclassificacoes")]
	RetListaReclassificacoes(in:&full_search, in:&page_num, in:&page_rows, in:&omit, in:&fields, in:&query, in:&sort, in:&doc, in:&status, out:&reclassificacoes)
	=> BaseERP.Estoque.RetSdtReclassificacoes(&SdtSessao, &SdtInputGet, &reclassificacoes, &RestCode);

	//-----------------------------------------------------------------------------------------------//
	// X X X X X X X X X
	//-----------------------------------------------------------------------------------------------//
	
	//[RestMethod(POST)]
	//[RestPath("v1/xxxxxxx")]
	//IncluirXxxxxxx(in:&doc, out:&output_schema)
	//=> Estoque.GravarXxxxxxx(&SdtSessao, &output_schema, &RestCode);	
	
	//[RestMethod(PUT)]
	//[RestPath("v1/xxxxxxx")]
	//AlterarXxxxxxx(in:&doc, out:&output_schema)
	//=> Estoque.GravarXxxxxxx(&SdtSessao, &output_schema, &RestCode);	
	
	//[RestMethod(DELETE)]
	//[RestPath("v1/xxxxxxx")]
	//ExcluirXxxxxxx(out:&output_schema)
	//=> Estoque.ExcluirXxxxxxx(&SdtSessao, &output_schema, &RestCode);
	
	//[RestMethod(GET)]
	//[RestPath("v1/xxxxxxx")]
	//RetSdtXxxxxxx(out:&output_schema)
	//=> Estoque.RetSdtXxxxxxx(&SdtSessao, &output_schema, &RestCode);

	//[RestMethod(GET)]
	//[RestPath("v1/xxxxxxx/list")]
	//DPRetXxxxxxx(out:&output_schema)
	//=> Estoque.DPRetXxxxxxx(&SdtSessao, &output_schema, &RestCode);
}
