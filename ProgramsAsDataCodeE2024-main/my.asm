   0x00005555555566bf <+0>:	endbr64
   0x00005555555566c3 <+4>:	sub    $0x28,%rsp
   0x00005555555566c7 <+8>:	mov    %fs:0x28,%rax
   0x00005555555566d0 <+17>:	mov    %rax,0x18(%rsp)
   0x00005555555566d5 <+22>:	xor    %eax,%eax
   0x00005555555566d7 <+24>:	lea    0xf(%rsp),%rcx
   0x00005555555566dc <+29>:	lea    0x10(%rsp),%rdx
   0x00005555555566e1 <+34>:	lea    0x14(%rsp),%r8
   0x00005555555566e6 <+39>:	lea    0x1ac1(%rip),%rsi        # 0x5555555581ae
   0x00005555555566ed <+46>:	call   0x555555556330 <__isoc99_sscanf@plt>
   0x00005555555566f2 <+51>:	cmp    $0x2,%eax
   0x00005555555566f5 <+54>:	jle    0x555555556717 <phase_3+88>
   0x00005555555566f7 <+56>:	cmpl   $0x7,0x10(%rsp)
   0x00005555555566fc <+61>:	ja     0x55555555680f <phase_3+336>
   0x0000555555556702 <+67>:	mov    0x10(%rsp),%eax
   0x0000555555556706 <+71>:	lea    0x1ab3(%rip),%rdx        # 0x5555555581c0
   0x000055555555670d <+78>:	movslq (%rdx,%rax,4),%rax
   0x0000555555556711 <+82>:	add    %rdx,%rax
   0x0000555555556714 <+85>:	notrack jmp *%rax
   0x0000555555556717 <+88>:	call   0x555555556eea <explode_bomb>
   0x000055555555671c <+93>:	jmp    0x5555555566f7 <phase_3+56>
   0x000055555555671e <+95>:	mov    $0x78,%eax
   0x0000555555556723 <+100>:	cmpl   $0x177,0x14(%rsp)
   0x000055555555672b <+108>:	je     0x555555556819 <phase_3+346>
   0x0000555555556731 <+114>:	call   0x555555556eea <explode_bomb>
   0x0000555555556736 <+119>:	mov    $0x78,%eax
   0x000055555555673b <+124>:	jmp    0x555555556819 <phase_3+346>
   0x0000555555556740 <+129>:	mov    $0x79,%eax
   0x0000555555556745 <+134>:	cmpl   $0xbb,0x14(%rsp)
   0x000055555555674d <+142>:	je     0x555555556819 <phase_3+346>
   0x0000555555556753 <+148>:	call   0x555555556eea <explode_bomb>
   0x0000555555556758 <+153>:	mov    $0x79,%eax
   0x000055555555675d <+158>:	jmp    0x555555556819 <phase_3+346>
   0x0000555555556762 <+163>:	mov    $0x77,%eax
   0x0000555555556767 <+168>:	cmpl   $0xe6,0x14(%rsp)
   0x000055555555676f <+176>:	je     0x555555556819 <phase_3+346>
   0x0000555555556775 <+182>:	call   0x555555556eea <explode_bomb>
   0x000055555555677a <+187>:	mov    $0x77,%eax
   0x000055555555677f <+192>:	jmp    0x555555556819 <phase_3+346>
   0x0000555555556784 <+197>:	mov    $0x66,%eax
   0x0000555555556789 <+202>:	cmpl   $0x155,0x14(%rsp)
   0x0000555555556791 <+210>:	je     0x555555556819 <phase_3+346>
   0x0000555555556797 <+216>:	call   0x555555556eea <explode_bomb>
   0x000055555555679c <+221>:	mov    $0x66,%eax
   0x00005555555567a1 <+226>:	jmp    0x555555556819 <phase_3+346>
   0x00005555555567a3 <+228>:	mov    $0x6f,%eax
   0x00005555555567a8 <+233>:	cmpl   $0x10c,0x14(%rsp)
   0x00005555555567b0 <+241>:	je     0x555555556819 <phase_3+346>
   0x00005555555567b2 <+243>:	call   0x555555556eea <explode_bomb>
   0x00005555555567b7 <+248>:	mov    $0x6f,%eax
   0x00005555555567bc <+253>:	jmp    0x555555556819 <phase_3+346>
   0x00005555555567be <+255>:	mov    $0x72,%eax
   0x00005555555567c3 <+260>:	cmpl   $0x274,0x14(%rsp)
   0x00005555555567cb <+268>:	je     0x555555556819 <phase_3+346>
   0x00005555555567cd <+270>:	call   0x555555556eea <explode_bomb>
   0x00005555555567d2 <+275>:	mov    $0x72,%eax
   0x00005555555567d7 <+280>:	jmp    0x555555556819 <phase_3+346>
   0x00005555555567d9 <+282>:	mov    $0x61,%eax
   0x00005555555567de <+287>:	cmpl   $0x18b,0x14(%rsp)
   0x00005555555567e6 <+295>:	je     0x555555556819 <phase_3+346>
   0x00005555555567e8 <+297>:	call   0x555555556eea <explode_bomb>
   0x00005555555567ed <+302>:	mov    $0x61,%eax
   0x00005555555567f2 <+307>:	jmp    0x555555556819 <phase_3+346>
   0x00005555555567f4 <+309>:	mov    $0x6d,%eax
   0x00005555555567f9 <+314>:	cmpl   $0x2a4,0x14(%rsp)
   0x0000555555556801 <+322>:	je     0x555555556819 <phase_3+346>
   0x0000555555556803 <+324>:	call   0x555555556eea <explode_bomb>
   0x0000555555556808 <+329>:	mov    $0x6d,%eax
   0x000055555555680d <+334>:	jmp    0x555555556819 <phase_3+346>
   0x000055555555680f <+336>:	call   0x555555556eea <explode_bomb>
   0x0000555555556814 <+341>:	mov    $0x7a,%eax
   0x0000555555556819 <+346>:	cmp    %al,0xf(%rsp)
   0x000055555555681d <+350>:	jne    0x555555556834 <phase_3+373>
   0x000055555555681f <+352>:	mov    0x18(%rsp),%rax
   0x0000555555556824 <+357>:	sub    %fs:0x28,%rax
   0x000055555555682d <+366>:	jne    0x55555555683b <phase_3+380>
   0x000055555555682f <+368>:	add    $0x28,%rsp
   0x0000555555556833 <+372>:	ret
   0x0000555555556834 <+373>:	call   0x555555556eea <explode_bomb>
   0x0000555555556839 <+378>:	jmp    0x55555555681f <phase_3+352>
   0x000055555555683b <+380>:	call   0x555555556280 <__stack_chk_fail@plt>