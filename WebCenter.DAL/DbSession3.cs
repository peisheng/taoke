﻿ 
 
using WebCenter.IDAL;

namespace WebCenter.DAL
{
    public partial class DbSession:IDbSession  
    {   
	
	public IDAL.IproductRepository productRepository { get { return new productRepository(); } }
	}
}